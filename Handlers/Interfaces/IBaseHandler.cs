using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;
using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces
{
    public interface IBaseHandler<TModel> :
        IRequestHandler<IGetAllQuery<TModel>, IEnumerable<TModel>>,
        IRequestHandler<IGetByIdQuery<TModel>, TModel>,
        IRequestHandler<IInsertCommand<TModel>, TModel>,
        IRequestHandler<IDeleteCommand, bool>
        where TModel : IModel
    {

    }
}
