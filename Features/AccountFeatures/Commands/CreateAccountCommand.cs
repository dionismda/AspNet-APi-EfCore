using AspNet_Api_EfCore.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.AccountFeatures.Commands
{
    public class CreateAccountCommand : IRequest<User>
    {
        [Required]
        public string Name { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public string Bio { get; private set; }
        [Required]
        public string Image { get; private set; }
        public CreateAccountCommand(string name, string email, string password, string image, string bio)
        {
            Name = name;
            Email = email;
            Password = password;
            Bio = bio;
            Image = image;
        }
    }
}
