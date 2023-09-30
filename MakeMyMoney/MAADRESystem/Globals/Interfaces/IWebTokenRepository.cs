using System.Security.Claims;

namespace MakeMyMoney.MAADRESystem.Globals.Interfaces
{
    public interface IWebTokenRepository
    {
        Task<string> GetTokenAsync();
        Task SaveTokenAsync(string token);
        Task RemoveTokenAsync();
        IEnumerable<Claim> ParseClaimsFromJwt(string jwt);
    }
}
