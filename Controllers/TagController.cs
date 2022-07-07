using AspNet_Api_EfCore.Features.TagFeatures.Commands;
using AspNet_Api_EfCore.ViewModels.Accounts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_Api_EfCore.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class TagController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public TagController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<AccountViewModel> Post(
            [FromServices] IMediator mediator,
            [FromBody] CreateTagRequest createTagRequest
            )
        {
            var response = mediator.Send(createTagRequest);
            return Ok(response);
        }

    }
}
