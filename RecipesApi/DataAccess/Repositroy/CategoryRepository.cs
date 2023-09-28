using RecipesApi.DataAccess.Data;
using RecipesApi.DataAccess.Repositroy.IRepository;
using RecipesApi.Model;

namespace RecipesApi.DataAccess.Repositroy
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
      
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public async Task<Category> UpdateAsync(Guid id,Category cat)
        {
            //villa.UpdatedDate = DateTime.Now;
            var cate=  _db.Category.FirstOrDefault(c => c.Id == id);
            cate.Name = cat.Name;
            _db.Category.Update(cate);
            await _db.SaveChangesAsync();
            return cat;
        }
    }
}
