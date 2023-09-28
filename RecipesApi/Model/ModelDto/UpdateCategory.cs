using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.ModelDto
{
    public class UpdateCategory
    {
       // public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
