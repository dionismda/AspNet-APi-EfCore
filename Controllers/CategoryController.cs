using AspNet_Api_EfCore.Features.CategoryFeatures.Commands;
using AspNet_Api_EfCore.Features.CategoryFeatures.Queries;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.ValueObjects;
using AspNet_Api_EfCore.ViewModels;
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
        public async Task<ActionResult<ResultViewModel<Pagination<Category>>>> Get([FromQuery] GetAllCategoryQuery getAllCategory)
        {
            return Ok(await _mediator.Send(getAllCategory));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResultViewModel<Category>>> GetById([FromRoute] GetCategoryQuery getCategory)
        {
            return Ok(await _mediator.Send(getCategory));
        }

        [HttpPost]
        public async Task<ActionResult<ResultViewModel<Category>>> Post([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            return Ok(await _mediator.Send(createCategoryCommand));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResultViewModel<Category>>> Put([FromRoute] int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            updateCategoryCommand.Id = id;

            return Ok(await _mediator.Send(updateCategoryCommand));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            await _mediator.Send(deleteCategoryCommand);

            return NoContent();
        }

    }
}
