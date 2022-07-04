using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IDeleteCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
