using AspNet_Api_EfCore.Handlers.Interfaces.Commons;

namespace AspNet_Api_EfCore.Features.CategoryFeatures.Commands
{
    public class DeleteCategoryCommand : IDeleteCommand
    {
        public int Id { get; set; }
    }
}
