namespace RecipesApi.Model.RedisModel
{
    public class FavouriteList
    {
        public string Id { get; set; }
        public List<Guid> recipesId { get; set; }

    }
}
