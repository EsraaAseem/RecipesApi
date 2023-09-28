using RecipesApi.DataAccess.Data;
using RecipesApi.DataAccess.Repositroy.IRepository;
using RecipesApi.Model;

namespace RecipesApi.DataAccess.Repositroy
{
    public class RecipesRepository : Repository<Recipe>, IRecipesRepository
    {
        private readonly ApplicationDbContext _db;

        public RecipesRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        public async Task<Recipe> UpdateAsync(Guid id, Recipe recipe)
        {
            //villa.UpdatedDate = DateTime.Now;
            var rec = _db.Recipe.FirstOrDefault(c => c.Id == id);
            rec.Name = recipe.Name;
            rec.Description = recipe.Description;
            rec.imgUrl = recipe.imgUrl;
            rec.categoryId = recipe.categoryId;
            rec.Ingredients = recipe.Ingredients;
            _db.Recipe.Update(rec);
            await _db.SaveChangesAsync();
            return rec;
        }
    }
}
