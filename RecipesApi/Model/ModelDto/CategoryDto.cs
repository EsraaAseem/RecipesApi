using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.ModelDto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
