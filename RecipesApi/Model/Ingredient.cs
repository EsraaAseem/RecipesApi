using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model
{
    [Owned]
    public class Ingredient
    {
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
