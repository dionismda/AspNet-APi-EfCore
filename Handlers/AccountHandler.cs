using AspNet_Api_EfCore.Features.AccountFeatures.Commands;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using AspNet_Api_EfCore.Repositories.Queries;
using AspNet_Api_EfCore.Services.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace AspNet_Api_EfCore.Handlers
{
    public class AccountHandler :
        IRequestHandler<LoginAccountCommand, Token>,
        IRequestHandler<CreateAccountCommand, User>,
        IRequestHandler<UploadImageAccountCommand, User>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public AccountHandler(IUserRepository userRepository,
                              IPasswordHasher<User> passwordHasher,
                              ITokenService tokenService,
                              IEmailService emailService,
                              IAuthenticatedUserService authenticatedUserService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _emailService = emailService;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<Token> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserRolesByEmail(request.Email);

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

        public async Task<User> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
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

        public async Task<User> Handle(UploadImageAccountCommand request, CancellationToken cancellationToken)
        {
            string fileName = $"{Guid.NewGuid().ToString()}.jpg";
            string data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(request.Base64Image, "");
            byte[] bytes = Convert.FromBase64String(data);

            try
            {
                await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha interna no servidor");
            }

            User user = await _userRepository.GetUser(UserQueries.GetByEmail(_authenticatedUserService.Email));

            if (user == null)
                throw new Exception("Usuário não encontrado");

            user.Image = $"https://localhost:0000/images/{fileName}";

            return await _userRepository.Update(user);
        }
    }
}
