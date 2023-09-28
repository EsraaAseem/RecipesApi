using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApi.Model
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string imgUrl { get; set; }
        public List<Ingredient> Ingredients { get; set;}
        [ForeignKey("categoryId")]
        public Guid categoryId { get; set; }
        [ValidateNever]
        public Category category { get; set; }
    }
}
