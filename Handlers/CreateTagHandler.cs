using AspNet_Api_EfCore.Features.TagFeatures.Commands;
using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers
{
    public class CreateTagHandler : ICreateTagHandler
    {
        public Task<CreateTagResponse> Handle(ICreateTagRequest request, CancellationToken cancellationToken)
        {

            CreateTagRequest command = (CreateTagRequest)request;

            return Task.FromResult(new CreateTagResponse
            {
                Id = 111,
                Name = command.Name,
                Slug = command.Slug
            });
        }
    }
}
