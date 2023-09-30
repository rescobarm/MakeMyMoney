using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MakeMyMoney.MAADRESystem.Globals.Cntrlls;
using Microsoft.JSInterop;
using System.Security.Claims;
using System.Text.Json;

namespace MakeMyMoney.MAADRESystem.Globals.Data
{
    public class WebTokenRepository : ITokenRepository
    {
        private readonly IJSRuntime _ijsrt;
        public static readonly string tknKey = "TOKENKEY";
        public WebTokenRepository(IJSRuntime ijsrt)
        {
            this._ijsrt = ijsrt;
        }

        public async Task<string> GetTokenAsync()
        {
            var tkn = await _ijsrt.GetFromLocalStorage(tknKey);
            return tkn;
        }

        public IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parseRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
                    foreach (var parseRole in parseRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parseRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }
                keyValuePairs.Remove(ClaimTypes.Role);
            }
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task RemoveTokenAsync()
        {
            await _ijsrt.RemoveItem(tknKey);
        }

        public async Task SaveTokenAsync(string token)
        {
            await _ijsrt.SetInLocalStorage(tknKey, token);
        }

        // Implementar los métodos usando IJSRuntime
        // ...
    }
}
