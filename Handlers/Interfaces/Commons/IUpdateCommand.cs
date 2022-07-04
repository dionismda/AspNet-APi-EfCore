using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IUpdateCommand<TModel> : ICommand<TModel> where TModel : IModel
    {
    }
}
