using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserRoles(string email);
    }
}
