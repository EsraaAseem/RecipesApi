namespace RecipesApi.Model.RedisModel
{
    public class ShoppingList
    {
        public ShoppingList()
        {
        }

        public ShoppingList(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<Ingredients> Ingredients { get; set;} = new List<Ingredients>();
    }
}
