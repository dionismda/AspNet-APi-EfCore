using AspNet_Api_EfCore.ValueObjects;

namespace AspNet_Api_EfCore.Interfaces
{
    public interface IRepository<TModel> where TModel : IModel
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Add(TModel entity);
        Task<TModel> Update(TModel entity);
        Task<bool> Delete(TModel entity);
        Task<IPagination<TModel>> GetPaginationAsync(PaginationRequest request, CancellationToken cancellationToken);
    }

}
