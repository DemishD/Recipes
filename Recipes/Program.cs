using Recipes.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<User, IdentityRole>()
.AddEntityFrameworkStores<RecipeContext>();

// ��� ��������� �� Entity Framework � ��������� ������������
builder.Services.AddDbContext<RecipeContext>();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// ��������� CORS ��� ���������� �������� � ������ ����������
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

// ����������� ����� �������������
builder.Services.Configure<IdentityOptions>(options =>
{
    // ��������� ���������� �������������
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

// ����������� ���� ��������������
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
    // ���������� 401 ��� ������ ����������� ������� ��� ����
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
