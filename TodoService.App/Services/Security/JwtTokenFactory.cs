using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TodoService.Domain.Services.Security;
using TodoService.Identity;

namespace App.Services.Security
{
    public sealed class JwtTokenFactory : ITokenFactory<ApplicationUser>
    {
        private readonly SigningTokenSettings tokenSettings;

        public JwtTokenFactory(IOptionsSnapshot<SigningTokenSettings> tokenSettings)
        {
            this.tokenSettings = tokenSettings.Value;
        }

        public string GenerateToken(ApplicationUser user)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("AccountId", user.AccountId.ToString())
            };

            var credetials = new SigningCredentials(
                    tokenSettings.GetSecretKey(),
                    tokenSettings.SigningAlgorithm);

            var expires = DateTime.UtcNow.AddMinutes(Double.Parse(tokenSettings.DurationInMinutes));

            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: credetials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
