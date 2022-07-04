using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IUpdateCommand<Category>
    {
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
