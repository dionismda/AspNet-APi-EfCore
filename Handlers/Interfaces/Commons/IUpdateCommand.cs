using AspNet_Api_EfCore.Interfaces;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IUpdateCommand<TModel> : IRequest<TModel> where TModel : IModel
    {
    }
}
