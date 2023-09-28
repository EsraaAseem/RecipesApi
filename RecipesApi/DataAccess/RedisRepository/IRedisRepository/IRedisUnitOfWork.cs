namespace RecipesApi.DataAccess.RedisRepository.IRedisRepository
{
    public interface IRedisUnitOfWork
    {
       IShoppingListRepository shoppingLists{ get; }
        IFavouriteListRepository favouriteLists { get; }
    }
}
