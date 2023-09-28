using System.Text.Json.Serialization;

namespace RecipesApi.Model.ModelDto
{
    public class userDto
    {
        public string message { get; set; }
        public bool isAuthenticated { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
