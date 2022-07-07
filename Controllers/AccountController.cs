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
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public AccountController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<ActionResult<AccountViewModel>> Post([FromBody] CreateAccountCommand createAccountCommand)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new ResultViewModel<AccountViewModel>(ModelState.GetErrors()));

        //    AccountViewModel account = _mapper.Map<AccountViewModel>(await _mediator.Send(createAccountCommand));

        //    return Ok(new ResultViewModel<AccountViewModel>(account));
        //}

        //[AllowAnonymous]
        //[HttpPost("login")]
        //public async Task<ActionResult<Token>> Login([FromBody] LoginAccountCommand loginAccountCommand)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(new ResultViewModel<Token>(ModelState.GetErrors()));

        //    Token token = await _mediator.Send(loginAccountCommand);

        //    return Ok(new ResultViewModel<Token>(token));
        //}

        //[Authorize]
        //[HttpPost("upload-image")]
        //public async Task<ActionResult<AccountViewModel>> UploadImage([FromBody] UploadImageAccountCommand uploadImageAccountCommand)
        //{

        //    if (!ModelState.IsValid)
        //        return BadRequest(new ResultViewModel<AccountViewModel>(ModelState.GetErrors()));

        //    AccountViewModel account = _mapper.Map<AccountViewModel>(await _mediator.Send(uploadImageAccountCommand));

        //    return Ok(new ResultViewModel<AccountViewModel>(account));
        //}
    }
}
