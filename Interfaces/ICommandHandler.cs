namespace AspNet_Api_EfCore.Interfaces
{
    public interface ICommandHandler<in TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }

    public interface ICommandHanlder<in TRequestId, in TRequest, TResponse>
        where TRequestId : IRequestId
        where TRequest : ICommand<TResponse>
    {
        Task<TResponse> Handle(TRequestId id, TRequest request);
    }


}
