using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNet_Api_EfCore.Repositories
{
    public class UserRepository : BaseRepository<User, BlogDataContext>, IUserRepository
    {
        public UserRepository(BlogDataContext blogDataContext) : base(blogDataContext)
        {
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).FirstOrDefaultAsync(expression);
        }

        public async Task<User> GetUserRolesByEmail(string email)
        {
            return await _context
                        .Users
                        .AsNoTracking()
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
