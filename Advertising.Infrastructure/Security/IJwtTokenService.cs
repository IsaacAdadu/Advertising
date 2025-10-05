using Advertising.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Infrastructure.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, IList<string> roles);
    }
}
