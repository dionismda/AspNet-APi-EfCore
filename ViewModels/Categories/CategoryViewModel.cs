using AspNet_Api_EfCore.Interfaces;

namespace AspNet_Api_EfCore.ViewModels.Categories
{
    public class CategoryViewModel : IViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
