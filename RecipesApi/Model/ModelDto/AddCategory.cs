using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.ModelDto
{
    public class AddCategory
    {
        [Required]
        public string Name { get; set; }
    }
}
