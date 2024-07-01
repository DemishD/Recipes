namespace Recipes.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
