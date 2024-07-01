namespace Recipes.Models
{
    public class RecipeIngredients
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
