using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Api_EfCore.Repositories
{
    public class UserRepository : BaseRepository<User, BlogDataContext>, IUserRepository
    {
        public UserRepository(BlogDataContext blogDataContext) : base(blogDataContext)
        {
        }

        public async Task<User> GetUserRoles(string email)
        {
            return await _context
                        .Users
                        .AsNoTracking()
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
