namespace Recipes.Models
{
    public class Step
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
