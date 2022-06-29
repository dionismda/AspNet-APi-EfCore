using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Queries
{
    public class GetAllCategoryQuery : ICommand<IEnumerable<Category>>
    {

    }
}
