using BookStore.App.Interfaces.Services;
using BookStore.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Infrastructure
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {

        public string GenerateToken(UserEntity userEntity)
        {
            var claims = new[]
            {
                new Claim("sub", userEntity.Id.ToString()),
                new Claim("userRole", userEntity.Role.ToString()),
                new Claim("name", userEntity.UserName),
            };

            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                            SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
