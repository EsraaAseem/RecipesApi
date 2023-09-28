using System.Net;

namespace RecipesApi.DataAccess.Helper
{
    public class ApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool isSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
