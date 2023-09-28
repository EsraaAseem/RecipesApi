using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.RedisModel
{
    public class Ingredients
    {
        Guid Id { get; set; } = new Guid();
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
