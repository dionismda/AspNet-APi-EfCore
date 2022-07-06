using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IInsertCommand<Category>
    {
        [Required]
        public string Name { get; private set; }
        public string Slug { get; private set; }

        public CreateCategoryCommand(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
