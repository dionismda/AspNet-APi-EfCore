using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.ViewModels.Accounts;
using AutoMapper;

namespace AspNet_Api_EfCore.Mappers
{
    public class AccountMap : Profile
    {
        public AccountMap()
        {
            CreateMap<User, AccountViewModel>();
        }

    }
}
