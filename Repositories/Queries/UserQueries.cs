using AspNet_Api_EfCore.Models;
using System.Linq.Expressions;

namespace AspNet_Api_EfCore.Repositories.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
