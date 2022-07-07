using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Features.TagFeatures.Commands
{
    public class CreateTagRequest : ICreateTagRequest
    {
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
