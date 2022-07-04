using AspNet_Api_EfCore.Handlers.Interfaces.Commons;
using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Queries
{
    public class GetCategoryQuery : IGetByIdQuery<Category>
    {
        public int Id { get; set; }
    }
}
