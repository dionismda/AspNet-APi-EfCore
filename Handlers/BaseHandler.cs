using AspNet_Api_EfCore.Handlers.Interfaces;
using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers
{
    public abstract class BaseHandler<TModel> : IBaseHandler<TModel> where TModel : class, IModel
    {
        public abstract Task<IEnumerable<TModel>> Handle(IGetAllQuery<TModel> request);
        public abstract Task<TModel> Handle(IGetByIdQuery<TModel> request);
        public abstract Task<TModel> Handle(IRequestId id, IUpdateCommand<TModel> request);
        public abstract Task<TModel> Handle(IInsertCommand<TModel> request);
        public abstract Task<bool> Handle(IDeleteCommand request);
    }
}
