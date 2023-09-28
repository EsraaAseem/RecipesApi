using RecipesApi.DataAccess.RedisRepository.IRedisRepository;
using RecipesApi.Model.RedisModel;
using StackExchange.Redis;

namespace RecipesApi.DataAccess.RedisRepository.RedisRepository
{
    public class FavouriteListRepository : RedisRepository<FavouriteList>, IFavouriteListRepository
    {
        public FavouriteListRepository(IConnectionMultiplexer redis) : base(redis,"favouriteList")
        {
        }
    }
}
