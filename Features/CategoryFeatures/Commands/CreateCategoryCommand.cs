using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : ICommand<Category>
    {
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
