using System.Linq.Expressions;

namespace AspNet_Api_EfCore.Interfaces
{
    public interface IRepository<TModel> where TModel : class, IModel
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Add(TModel entity);
        Task<TModel> Update(TModel entity);
        Task<bool> Delete(TModel entity);
    }

}
