namespace Recipes.Models
{
    public class RecipeSteps
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Step Step { get; set; }
    }
}
