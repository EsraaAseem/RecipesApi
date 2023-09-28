using RecipesApi.Model;

namespace RecipesApi.DataAccess.Repositroy.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> UpdateAsync(Guid id,Category cat);

    }
}
