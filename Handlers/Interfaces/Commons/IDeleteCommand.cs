using MediatR;

namespace AspNet_Api_EfCore.Handlers.Interfaces.Commons
{
    public interface IDeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
