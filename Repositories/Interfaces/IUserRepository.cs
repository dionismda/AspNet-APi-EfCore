using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using System.Linq.Expressions;

namespace AspNet_Api_EfCore.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserRolesByEmail(string email);
        Task<User> GetUser(Expression<Func<User, bool>> expression);
    }
}
