using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Interfaces
{
    public interface ITokenRepository
    {
        Task<string> GetTokenAsync();
        Task SaveTokenAsync(string token);
        Task RemoveTokenAsync();
        IEnumerable<Claim> ParseClaimsFromJwt(string jwt);
    }
}
