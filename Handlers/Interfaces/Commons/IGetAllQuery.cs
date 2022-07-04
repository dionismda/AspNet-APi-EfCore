using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IGetAllQuery<TModel> : ICommand<IEnumerable<TModel>> where TModel : IModel
    {
    }
}
