using AspNet_Api_EfCore.Features.TagFeatures.Commands;
using AspNet_Api_EfCore.Interfaces;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces
{
    public interface ICreateTagHandler : IRequestHandler<ICreateTagRequest, CreateTagResponse>
    {
    }
}
