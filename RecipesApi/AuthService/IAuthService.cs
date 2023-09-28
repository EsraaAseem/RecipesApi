using RecipesApi.Model.ModelDto;
using RecipesApi.Model;

namespace RecipesApi.AuthService
{
    public interface IAuthService
    {
        Task<userDto> LoginAsync(LoginDto Input);
        Task<userDto> RegisterAsync(RegisterDto Input);
        Task<userDto> GetCurentUser();
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<userDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<string> GetUserId();
        Task<ApplicationUser> GetUsers();
    }
}
