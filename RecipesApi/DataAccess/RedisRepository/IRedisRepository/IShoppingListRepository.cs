using RecipesApi.DataAccess.RedisRepository.RedisRepository;
using RecipesApi.Model.RedisModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesApi.DataAccess.RedisRepository.IRedisRepository
{ 
    public interface IShoppingListRepository:IredisRepository<ShoppingList>
    {
    }
}
