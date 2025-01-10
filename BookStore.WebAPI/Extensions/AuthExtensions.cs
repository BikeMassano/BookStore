using BookStore.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.WebAPI.Extensions
{
    public static class AuthExtensions
    {
        public static void AddAuth(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var authSettings = configuration.GetSection(nameof(JwtOptions))
                .Get<JwtOptions>();

            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(authSettings!.SecretKey))
                    };

                    o.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["SuperCookies"];
                        
                            return Task.CompletedTask;
                        }
                    };
                });
            serviceCollection.AddAuthorization();
        }
    }
}
