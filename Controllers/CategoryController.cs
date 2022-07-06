using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using AspNet_Api_EfCore.ViewModels;
using AspNet_Api_EfCore.ViewModels.Categories;
using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get([FromQuery] GetAllCategoryQuery getAllCategory)
        {
            IEnumerable<CategoryViewModel> categories = _mapper.Map<IEnumerable<CategoryViewModel>>(await _mediator.Send(getAllCategory));
            return Ok(new ResultViewModel<IEnumerable<CategoryViewModel>>(categories));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> GetById([FromRoute] GetCategoryQuery getCategory)
        {
            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _mediator.Send(getCategory));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Post([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<CategoryViewModel>(ModelState.GetErrors()));

            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _mediator.Send(createCategoryCommand));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryViewModel>> Put([FromRoute] int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<CategoryViewModel>(ModelState.GetErrors()));

            updateCategoryCommand.Id = id;

            CategoryViewModel category = _mapper.Map<CategoryViewModel>(await _mediator.Send(updateCategoryCommand));
            return Ok(new ResultViewModel<CategoryViewModel>(category));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            await _mediator.Send(deleteCategoryCommand);

            return NoContent();
        }

    }
}
