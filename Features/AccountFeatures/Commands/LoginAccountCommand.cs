using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.AccountFeatures.Commands
{
    public class LoginAccountCommand : ICommand<Token>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
