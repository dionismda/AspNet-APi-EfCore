using AspNet_Api_EfCore.Features.AccountFeatures.Commands;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.ValueObject;
using Microsoft.AspNetCore.Identity;

namespace AspNet_Api_EfCore.Handlers
{
    public class AccountHandler :
        ICommandHandler<LoginAccountCommand, Token>,
        ICommandHandler<CreateAccountCommand, User>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AccountHandler(IUserRepository userRepository,
                              IPasswordHasher<User> passwordHasher,
                              ITokenService tokenService,
                              IEmailService emailService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<Token> Handle(LoginAccountCommand request)
        {
            User? user = await _userRepository.GetUserRoles(request.Email);

            if (user == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                throw new Exception("Usuário ou senha inválidos");
            }

            return new Token
            {
                token = _tokenService.GenerateToken(user)
            };
        }

        public async Task<User> Handle(CreateAccountCommand request)
        {
            User newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Slug = request.Email.Replace("@", "-").Replace(".", "-"),
                PasswordHash = _passwordHasher.HashPassword(new User(), request.Password),
                Bio = request.Bio,
                Image = request.Image,
            };

            User user = await _userRepository.Add(newUser);

            _emailService.Send(user.Name, user.Email, "Bem vindo", "Bem vindo ao blog");

            return user;
        }
    }
}
