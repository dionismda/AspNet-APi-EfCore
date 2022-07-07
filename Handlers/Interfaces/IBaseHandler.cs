using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ViewModels;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces
{
    public interface IBaseHandler<TModel> :
        IRequestHandler<IGetAllQuery<TModel>, IResultViewModel<IPagination<TModel>>>,
        IRequestHandler<IGetByIdQuery<TModel>, IResultViewModel<TModel>>,
        IRequestHandler<IInsertCommand<TModel>, IResultViewModel<TModel>>,
        IRequestHandler<IUpdateCommand<TModel>, IResultViewModel<TModel>>,
        IRequestHandler<IDeleteCommand, bool>
        where TModel : IModel
    {

    }
}
