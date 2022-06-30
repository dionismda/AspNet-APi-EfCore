using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.AccountFeatures.Commands
{
    public class UploadImageAccountCommand: ICommand<User>
    {
        [Required]
        public string Base64Image { get; set; }
    }
}
