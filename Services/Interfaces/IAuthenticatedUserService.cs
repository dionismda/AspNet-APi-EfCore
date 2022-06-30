using System.Security.Claims;

namespace AspNet_Api_EfCore.Services.Interfaces
{
    public interface IAuthenticatedUserService
    {
        public string Email { get; }
        public string Name { get; } 
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
