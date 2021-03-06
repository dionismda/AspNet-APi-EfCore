using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ViewModels;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IInsertCommand<TModel> : IRequest<IResultViewModel<TModel>> where TModel : IModel
    {
    }
}
