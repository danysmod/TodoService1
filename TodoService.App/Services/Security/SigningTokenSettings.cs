using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using TodoService.Domain.Services.Security;

namespace App.Services.Security
{
    public sealed class SigningTokenSettings
    {
        public string Key { get; set; }

        public string SigningAlgorithm { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string DurationInMinutes { get; set; }

        public SymmetricSecurityKey GetSecretKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Key));
    }
}
