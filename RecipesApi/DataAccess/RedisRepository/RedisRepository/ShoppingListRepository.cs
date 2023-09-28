using RecipesApi.DataAccess.RedisRepository.IRedisRepository;
using RecipesApi.Model.RedisModel;
using StackExchange.Redis;

namespace RecipesApi.DataAccess.RedisRepository.RedisRepository
{
    public class ShoppingListRepository : RedisRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(IConnectionMultiplexer redis) : base(redis,"shoppingList")
        {
        }
    }
}
