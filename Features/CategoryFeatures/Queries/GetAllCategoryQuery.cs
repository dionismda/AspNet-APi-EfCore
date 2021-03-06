using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Queries
{
    public class GetAllCategoryQuery : IGetAllQuery<Category>
    {
        public int? page { get; set; }
        public int? limit { get; set; }
    }
}
