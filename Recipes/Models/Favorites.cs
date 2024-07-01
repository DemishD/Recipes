namespace Recipes.Models
{
    public class Favorites
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }


    }
}
