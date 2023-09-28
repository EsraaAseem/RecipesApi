using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesApi.DataAccess.Helper;
using RecipesApi.DataAccess.Repositroy.IRepository;
using RecipesApi.Model;
using RecipesApi.Model.ModelDto;
using System.Net;

namespace RecipesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected readonly ApiResponse _response;

        public RecipesController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> getRecipes()
        {

            try
            {
                var Recipes = await _unitOfWork.Recipes.GetAllAsync(includeProperty: "category");
                _response.HttpStatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<RcipeDto>>(Recipes);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
        [HttpGet("rec")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> getRecipe()
        {

            try
            {
                var Recipe = await _unitOfWork.Recipes.GetFirstOrDefaultAsync();
                _response.HttpStatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<RcipeDto>(Recipe);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> createRecipe(AddRcipe recipe)
        {

            try
            {
                var villaexit = await _unitOfWork.Recipes.GetFirstOrDefaultAsync(u => u.Name == recipe.Name);
                if (villaexit != null)
                {
                    _response.HttpStatusCode = HttpStatusCode.BadRequest;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this villa is already exit" };
                    return _response;
                }
                var rec = _mapper.Map<Recipe>(recipe);
                await _unitOfWork.Recipes.CreateAsync(rec);
                _response.Result = rec;
                _response.HttpStatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }

        [HttpPut("{Id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateRecipe([FromRoute] Guid Id, [FromBody] UpdateRcipe recipeupdate)
        {
            /*if(Id!=categoryupdate.Id)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                return _response;
            }*/

            try
            {
                var recipeexit = await _unitOfWork.Recipes.GetFirstOrDefaultAsync(u => u.Id == Id);
                if (recipeexit == null)
                {
                    _response.HttpStatusCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this villa not found in the databasse" };
                    return _response;
                }
                // villaCreate.UpdatedDate = DateTime.Now;
                var rec = _mapper.Map<Recipe>(recipeupdate);
                await _unitOfWork.Recipes.UpdateAsync(Id, rec);
                _response.Result = rec;
                _response.HttpStatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{Id:guid}")]
        public async Task<ActionResult<ApiResponse>> DeleteRecipe([FromRoute] Guid Id)
        {

            try
            {
                var recipeexit = await _unitOfWork.Recipes.GetFirstOrDefaultAsync(u => u.Id == Id);
                if (recipeexit == null)
                {
                    _response.HttpStatusCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this category not found in the databasse" };
                    return _response;
                }
                // villaCreate.UpdatedDate = DateTime.Now;
                await _unitOfWork.Recipes.RemoveAsync(recipeexit);
                _response.HttpStatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
    }
}
