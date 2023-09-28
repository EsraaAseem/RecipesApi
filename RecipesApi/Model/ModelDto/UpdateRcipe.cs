using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.ModelDto
{
    public class UpdateRcipe
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string imgUrl { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Guid categoryId { get; set; }

    }
}
