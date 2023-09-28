namespace RecipesApi.DataAccess.Repositroy.IRepository
{
    public interface IUnitOfWork
    {
        IRecipesRepository Recipes { get; }
        ICategoryRepository Categories { get; }
      //  IAuthRepository TokenUser { get; }
        public void saveAsync();
    }
}
