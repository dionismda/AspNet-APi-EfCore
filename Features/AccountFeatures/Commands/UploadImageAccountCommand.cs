using AspNet_Api_EfCore.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.AccountFeatures.Commands
{
    public class UploadImageAccountCommand : IRequest<User>
    {
        [Required]
        public string Base64Image { get; set; }
    }
}
