using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Features.AccountFeatures.Commands;
using AspNet_Api_EfCore.Handlers;
using AspNet_Api_EfCore.ValueObject;
using AspNet_Api_EfCore.ViewModels;
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
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly AccountHandler _handler;

        public AccountController(
            AccountHandler userHandler,
            IMapper mapper)
        {
            _handler = userHandler;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AccountCreatedViewModel>> Post([FromBody] CreateAccountCommand createAccountCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<AccountCreatedViewModel>(ModelState.GetErrors()));

            AccountCreatedViewModel account = _mapper.Map<AccountCreatedViewModel>(await _handler.Handle(createAccountCommand));

            return Ok(new ResultViewModel<AccountCreatedViewModel>(account));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login([FromBody] LoginAccountCommand loginAccountCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Token>(ModelState.GetErrors()));

            Token token = await _handler.Handle(loginAccountCommand);

            return Ok(new ResultViewModel<Token>(token));
        }



    }
}
