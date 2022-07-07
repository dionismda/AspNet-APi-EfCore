using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.ViewModels;

namespace AspNet_Api_EfCore.Handlers
{
    public abstract class BaseHandler<TModel> : IBaseHandler<TModel> where TModel : class, IModel
    {
        public abstract Task<IResultViewModel<IPagination<TModel>>> Handle(IGetAllQuery<TModel> request, CancellationToken cancellationToken);
        public abstract Task<IResultViewModel<TModel>> Handle(IGetByIdQuery<TModel> request, CancellationToken cancellationToken);
        public abstract Task<IResultViewModel<TModel>> Handle(IInsertCommand<TModel> request, CancellationToken cancellationToken);
        public abstract Task<IResultViewModel<TModel>> Handle(IUpdateCommand<TModel> request, CancellationToken cancellationToken);
        public abstract Task<bool> Handle(IDeleteCommand request, CancellationToken cancellationToken);

    }
}
