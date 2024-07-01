namespace Recipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LikeNumber { get; set; }
        public int DislikeNumber { get; set; }
        public int PortionNumber { get; set; }
        public int CookingTime { get; set; }
        public string Image { get; set; }
        public int KithenTypeId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }
        //public virtual User User { get; set; }
        public virtual KitchenType KitchenType { get; set; }
        public virtual Category Category { get; set; }

    }
}
