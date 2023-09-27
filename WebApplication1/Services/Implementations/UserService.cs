using Microsoft.IdentityModel.Tokens;
using WebApplication1.DTOs;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.Services.Interfaces;
using WebApplication1.Exceptions;

namespace WebApplication1.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IConfiguration config;

        public UserService(IConfiguration config)
        {
            this.config = config;
        }

        public string Authenticate(UserDto user)
        {
            if (user.email == "string")
            {
                return GenerateJwtToken(user);
            }
            else
                throw new UnAuthorizeException("unauthorized");
        }

        private string GenerateJwtToken(UserDto user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.email),
               
            };
            if (user.password == "admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }

            var token = new JwtSecurityToken(
                signingCredentials: credentials,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(60)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
