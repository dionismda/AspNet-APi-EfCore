using AspNet_Api_EfCore.Features.TagFeatures.Commands;
using MediatR;

namespace AspNet_Api_EfCore.Interfaces
{
    public interface ICreateTagRequest : IRequest<CreateTagResponse>
    {
    }
}
