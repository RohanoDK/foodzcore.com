using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace foodzcore.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        public string RecipeName { get; set; }

        public string Image { get; set; } = "/uploads/default-recipe.jpg";

        public string Description { get; set; } 

        public decimal Price { get; set; }

        [Range(1, 5)]
        public int DifficultyRating { get; set; }

        [Range(1, 10)]
        public int TimeRating { get; set; }

        public Recipe()
        {

        }
    }
}
