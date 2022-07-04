using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers.Interfaces
{
    public interface IBaseHandler<TModel> :
        ICommandHandler<IGetAllQuery<TModel>, IEnumerable<TModel>>,
        ICommandHandler<IGetByIdQuery<TModel>, TModel>,
        ICommandHandler<IInsertCommand<TModel>, TModel>,
        ICommandHanlder<IRequestId, IUpdateCommand<TModel>, TModel>,
        ICommandHandler<IDeleteCommand, bool> 
        where TModel : IModel
    {

    }
}
