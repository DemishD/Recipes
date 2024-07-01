using Recipes.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<RecipeContext>();

// доб контекста бд Entity Framework в контейнер зависимостей
builder.Services.AddDbContext<RecipeContext>();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Добавляем CORS для разрешения запросов с других источников
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins("http://localhost:3000")
     .AllowAnyHeader()
    .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настраиваем опции идентификации
builder.Services.Configure<IdentityOptions>(options =>
{
    // Настройка блокировки пользователей
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

// Настраиваем куки аутентификации
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "BookShop";
    options.LoginPath = "/";
    options.AccessDeniedPath = "/";
    options.LogoutPath = "/";
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    // Возвращать 401 при вызове недоступных методов для роли
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
