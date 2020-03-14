using System;
using System.Collections.Generic;
using System.Text;

namespace TodoService.Domain.Services.Security
{
    public interface ITokenFactory<in TAppUser>
    {
        public string GenerateToken(TAppUser user);
    }
}
