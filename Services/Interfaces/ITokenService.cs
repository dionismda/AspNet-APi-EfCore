using AspNet_Api_EfCore.Models;

namespace AspNet_Api_EfCore.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
