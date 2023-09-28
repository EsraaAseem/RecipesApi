using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesApi.DataAccess.Helper;
using RecipesApi.DataAccess.RedisRepository.IRedisRepository;
using RecipesApi.Model.RedisModel;
using RecipesApi.Model.RedisModel.RedisModelDto;
using System.Net;

namespace RecipesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteListController : ControllerBase
    {
        private readonly IRedisUnitOfWork _redis;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;

        public FavouriteListController(IRedisUnitOfWork redis,IMapper mapper)
        {
            _redis = redis;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [Route("Id")]
        public async Task<ActionResult<ApiResponse>>getFavouriteList(string id)
        {
            if (id == null)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { "this id not Avaliable" };
            }
            else
            {
                var shopping = await _redis.favouriteLists.GetAsync(id);
                  _response.HttpStatusCode = HttpStatusCode.OK;
                    _response.Result = shopping;
            }
            return Ok(_response);
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> deleteList(string id)
        {
            if (id == null)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { "this id not Avaliable"};
            }
            else
            {
                var shopping=await _redis.favouriteLists.DeleteAsyc(id);
                if (shopping)
                {
                    _response.HttpStatusCode = HttpStatusCode.OK;
                    _response.Result = shopping;
                }
                else
                {
                    _response.HttpStatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>() { "this id not Found" };

                    _response.isSuccess = false;
                }
            }
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateFavouriteList(FavouriteList favourite)
        {
           // var shopping=_mapper.Map<ShoppingList>(shoppingdto);

            if (favourite.Id == null)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { "this id not Avaliable" };
            }
            else
            {
                var fav = await _redis.favouriteLists.UpdateAsyc(favourite, favourite.Id);
                if (fav != null)
                {
                    _response.HttpStatusCode = HttpStatusCode.OK;
                    _response.Result = fav;
                }
                else
                {
                    _response.HttpStatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "there is error in this method" };

                    _response.isSuccess = false;
                }
            }
            return Ok(_response);
        }
  
    }
}
