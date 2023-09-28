using RecipesApi.Model;

namespace RecipesApi.DataAccess.Repositroy.IRepository
{
    public interface IRecipesRepository:IRepository<Recipe>
    {
        Task<Recipe> UpdateAsync(Guid id, Recipe recipe);
    }
}
