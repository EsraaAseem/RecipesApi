using RecipesApi.DataAccess.Data;
using RecipesApi.DataAccess.Repositroy.IRepository;

namespace RecipesApi.DataAccess.Repositroy
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Recipes = new RecipesRepository(db);
            Categories = new CategoryRepository(db);
           // TokenUser=new AuthRepository(db);

        }
        public IRecipesRepository Recipes { get; private set; }


         public ICategoryRepository Categories { get; private set; }
       // public IAuthRepository TokenUser { get; private set; }

        public void saveAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
