using AutoMapper;
using RecipesApi.Model;
using RecipesApi.Model.ModelDto;
using RecipesApi.Model.RedisModel;
using RecipesApi.Model.RedisModel.RedisModelDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecipesApi.DataAccess.Helper
{
    public class autoMapping : Profile
    {
        public autoMapping()
        {
            CreateMap<Recipe,RcipeDto>().ReverseMap();
            CreateMap<Recipe, UpdateRcipe>().ReverseMap();
            CreateMap<Recipe, AddRcipe>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategory>().ReverseMap();
            CreateMap<Category, AddCategory>().ReverseMap();
            CreateMap<ShoppingList,shoppingListDto>().ReverseMap();
        }
    }
}
