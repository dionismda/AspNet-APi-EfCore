using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Handlers;
using AspNet_Api_EfCore.ValueObjects;
using AspNet_Api_EfCore.ViewModels;
using AspNet_Api_EfCore.ViewModels.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_Api_EfCore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryHandler _categoryHandler;
        private readonly IMapper _mapper;
        public CategoryController(CategoryHandler categoryHandler, IMapper mapper)
        {
            _categoryHandler = categoryHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get([FromQuery] GetAllCategoryQuery getAllCategory)
        {
            IEnumerable<CategoryViewModel> categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryHandler.Handle(getAllCategory));
            return Ok(new ResultViewModel<IEnumerable<CategoryViewModel>>(categories));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> GetById([FromRoute] GetCategoryQuery getCategory)
        {
            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _categoryHandler.Handle(getCategory));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Post([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<CategoryViewModel>(ModelState.GetErrors()));

            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _categoryHandler.Handle(createCategoryCommand));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> Put([FromRoute] RequestId requestId, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<CategoryViewModel>(ModelState.GetErrors()));

            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _categoryHandler.Handle(requestId, updateCategoryCommand));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            await _categoryHandler.Handle(deleteCategoryCommand);

            return NoContent();
        }

    }
}
