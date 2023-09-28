using Microsoft.AspNetCore.Identity;
using RecipesApi.Model.ModelDto;

namespace RecipesApi.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
