using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class UpdateCategoryCommand : IUpdateCommand<Category>
    {
        [JsonIgnore]
        public int Id { get; set; }   
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
