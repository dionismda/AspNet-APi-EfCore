using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Features.AccountFeatures.Commands;
using AspNet_Api_EfCore.Handlers;
using AspNet_Api_EfCore.ValueObjects;
using AspNet_Api_EfCore.ViewModels;
using AspNet_Api_EfCore.ViewModels.Accounts;
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
        public async Task<ActionResult<AccountViewModel>> Post([FromBody] CreateAccountCommand createAccountCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<AccountViewModel>(ModelState.GetErrors()));

            AccountViewModel account = _mapper.Map<AccountViewModel>(await _handler.Handle(createAccountCommand));

            return Ok(new ResultViewModel<AccountViewModel>(account));
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

        [Authorize]
        [HttpPost("upload-image")]
        public async Task<ActionResult<AccountViewModel>> UploadImage([FromBody] UploadImageAccountCommand uploadImageAccountCommand)
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<AccountViewModel>(ModelState.GetErrors()));

            AccountViewModel account = _mapper.Map<AccountViewModel>(await _handler.Handle(uploadImageAccountCommand));

            return Ok(new ResultViewModel<AccountViewModel>(account));
        }
    }
}
