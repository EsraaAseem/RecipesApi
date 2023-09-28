using RecipesApi.DataAccess.RedisRepository.IRedisRepository;
using StackExchange.Redis;

namespace RecipesApi.DataAccess.RedisRepository.RedisRepository
{
    public class RedisUnitOfWork : IRedisUnitOfWork
    {
       private readonly IConnectionMultiplexer _redis;
        public RedisUnitOfWork(IConnectionMultiplexer redis)
        {
            _redis = redis;
           shoppingLists = new ShoppingListRepository(_redis);
            favouriteLists = new FavouriteListRepository(_redis);
        }

        public IShoppingListRepository shoppingLists { get; private set; }
        public IFavouriteListRepository favouriteLists { get; private set;}
    }
}
