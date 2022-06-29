using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.AccountFeatures.Commands
{
    public class CreateAccountCommand : ICommand<User>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
