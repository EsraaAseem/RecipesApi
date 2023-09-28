using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Produces("text/json")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        protected readonly ApiResponse _response;

        public CategoryController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> getCategories()
        {

            try
            {
                var categories = await _unitOfWork.Categories.GetAllAsync();
                _response.HttpStatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<List<CategoryDto>>(categories);
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
        public async Task<ActionResult<ApiResponse>> createCategory(AddCategory category)
        {

            try
            {
                var Categoryexit = await _unitOfWork.Categories.GetFirstOrDefaultAsync(u => u.Name == category.Name);
                if (Categoryexit != null)
                {
                    _response.HttpStatusCode = HttpStatusCode.BadRequest;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this Category Alredy Exit is already exit" };
                    return _response;
                }
                var cat = _mapper.Map<Category>(category);
                await _unitOfWork.Categories.CreateAsync(cat);
                _response.Result = cat;
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

        public async Task<ActionResult<ApiResponse>> UpdateCategory([FromRoute] Guid Id,[FromBody]UpdateCategory categoryupdate)
        {
            /*if(Id!=categoryupdate.Id)
            {
                _response.HttpStatusCode = HttpStatusCode.BadRequest;
                _response.isSuccess = false;
                return _response;
            }*/

            try
            {
                var categoryexit = await _unitOfWork.Categories.GetFirstOrDefaultAsync(u => u.Id ==Id);
                if (categoryexit == null)
                {
                    _response.HttpStatusCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this villa not found in the databasse" };
                    return _response;
                }
                // villaCreate.UpdatedDate = DateTime.Now;
                var cat = _mapper.Map<Category>(categoryupdate);
                await _unitOfWork.Categories.UpdateAsync(Id,cat);
                _response.Result = cat;
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
        public async Task<ActionResult<ApiResponse>> DeleteCategory([FromRoute]Guid Id)
        {

            try
            {
                var categoryexit = await _unitOfWork.Categories.GetFirstOrDefaultAsync(u => u.Id == Id);
                if (categoryexit == null)
                {
                    _response.HttpStatusCode = HttpStatusCode.NotFound;
                    _response.isSuccess = false;
                    _response.ErrorMessages = new List<string>() { "this category not found in the databasse" };
                    return _response;
                }
                // villaCreate.UpdatedDate = DateTime.Now;
                await _unitOfWork.Categories.RemoveAsync(categoryexit);
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
