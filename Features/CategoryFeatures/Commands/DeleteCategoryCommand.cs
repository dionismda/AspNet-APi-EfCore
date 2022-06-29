using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}
