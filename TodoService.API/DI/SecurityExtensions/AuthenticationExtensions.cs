using App.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TodoService.Domain.Services.Security;
using TodoService.Identity;

namespace API.DI.Security
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthenticationPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<SigningTokenSettings>()
                    .Bind(configuration.GetSection("JwtSecurityToken"));

            services.AddScoped<ITokenFactory<ApplicationUser>, JwtTokenFactory>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityToken:Key"])),

                        ValidateIssuer = true,
                        ValidAudience = configuration["JwtSecurityToken:Audience"],
                        
                        ValidateAudience = true,
                        ValidIssuer = configuration["JwtSecurityToken:Issuer"],

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.FromSeconds(5),
                    };
                })
                .AddCookie();

            return services;
        }
    }
}
