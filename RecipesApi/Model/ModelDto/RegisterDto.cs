using System.ComponentModel.DataAnnotations;

namespace RecipesApi.Model.ModelDto
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisPlayName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
