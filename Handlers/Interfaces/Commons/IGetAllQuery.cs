using AspNet_Api_EfCore.Interfaces;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IGetAllQuery<TModel> : IRequest<IEnumerable<TModel>> where TModel : IModel
    {
    }
}
