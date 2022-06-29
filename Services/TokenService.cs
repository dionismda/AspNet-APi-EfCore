using AspNet_Api_EfCore.Configurations;
using AspNet_Api_EfCore.Extensions;
using AspNet_Api_EfCore.Interfaces;
using AspNet_Api_EfCore.Models;
using AspNet_Api_EfCore.ValueObject;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNet_Api_EfCore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {

            JWTSettings jwtSettings = AppSettingsConfig.Configuration.GetSection("JWTSettings").Get<JWTSettings>();
            byte[] key = Encoding.ASCII.GetBytes(jwtSettings.JwtKey);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var claims = user.GetClaims();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}