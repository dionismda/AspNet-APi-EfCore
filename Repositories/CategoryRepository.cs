using AspNet_Api_EfCore.Data;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.Repositories.Interfaces;

namespace AspNet_Api_EfCore.Repositories
{
    public class CategoryRepository : BaseRepository<Category, BlogDataContext>, ICategoryRepository
    {
        public CategoryRepository(BlogDataContext blogDataContext) : base(blogDataContext)
        {
        }


    }
}
