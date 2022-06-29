using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.ViewModels;
using AutoMapper;

namespace AspNet_Api_EfCore.Mappers
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryViewModel>();
        }

    }
}
