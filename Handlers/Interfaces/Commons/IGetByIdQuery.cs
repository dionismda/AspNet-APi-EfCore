using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IGetByIdQuery<TModel> : ICommand<TModel> where TModel : IModel
    {
        public int Id { get; set; }
    }
}
