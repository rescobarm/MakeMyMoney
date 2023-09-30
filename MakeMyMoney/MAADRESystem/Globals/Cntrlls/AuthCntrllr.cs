using MakeMyMoney.MAADRESystem.Globals.Data.WebServices;
using MakeMyMoney.MAADRESystem.Globals.Interfaces;
using MakeMyMoney.MAADRESystem.Globals.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MakeMyMoney.MAADRESystem.Globals.Cntrlls
{
    public interface ISignUpSrvc
    {
        Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials);
    }
    public interface ILogInSrvc
    {
        Task SetLogIn(string token);
        Task SetLogOut();
    }
    public class AuthCntrllr : AuthenticationStateProvider, ILogInSrvc, ISignUpSrvc
    {
        private readonly ILogger<AuthCntrllr> _logger;
        private readonly IWebTokenRepository tokenRepository;
        private readonly IUserFireBaseWSSrvc _sus;
        private readonly HttpClient _httpClient;

        private AuthenticationState Anonimo => new AuthenticationState(
            new ClaimsPrincipal()
        );

        public AuthCntrllr(ILogger<AuthCntrllr> logger, 
            IWebTokenRepository tokenRepository, HttpClient httpClient, IUserFireBaseWSSrvc sus)
        {//ISignUpSrvc
            _logger = logger;
            this.tokenRepository = tokenRepository;
            this._httpClient = httpClient;
            this._sus = sus;
        }
        public async Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials)
        {
            try
            {
                var uc = await this._sus.SignUpAsync(userCredentials);
                return uc;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($" --- ByREM *** => ({
                        ex.Message
                    });");
                throw;
            }
        }

        public async Task SetLogIn(string token)
        {
            try
            {
                //await tokenRepository.SaveTokenAsync(token);
                await tokenRepository.SaveTokenAsync(token).ConfigureAwait(false);

                //await ijsrt.SetInLocalStorage(tknKey, token);
                var authState = BuildAuthenticationState(token);
                NotifyAuthenticationStateChanged(Task.FromResult(authState));
            }
            catch (Exception ex)
            {
                //throw;  // Re-lanzando la excepción original.
                // o
                throw new InvalidOperationException("An error occurred while logging in.", ex);
                // Incluyendo la excepción original como una excepción interna.
            }

        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tkn = await tokenRepository.GetTokenAsync();
            if (string.IsNullOrEmpty(tkn) || tkn.ToLower() == "null")
            {
                return Anonimo;
            }
            return BuildAuthenticationState(tkn);
        }
        private AuthenticationState BuildAuthenticationState(string token)
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("auth", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt) as JwtSecurityToken;

            return jsonToken?.Claims ?? Enumerable.Empty<Claim>();
        }

        //private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        //{
        //    var claims = new List<Claim>();
        //    var payload = jwt.Split('.')[1];
        //    var jsonBytes = ParseBase64WithoutPadding(payload);
        //    var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        //    keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
        //    if (roles != null)
        //    {
        //        if (roles.ToString().Trim().StartsWith("["))
        //        {
        //            var parseRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
        //            foreach (var parseRole in parseRoles)
        //            {
        //                claims.Add(new Claim(ClaimTypes.Role, parseRole));
        //            }
        //        }
        //        else
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
        //        }
        //        keyValuePairs.Remove(ClaimTypes.Role);
        //    }
        //    claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
        //    return claims;
        //}

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }

        public async Task SetLogOut()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await tokenRepository.RemoveTokenAsync().ConfigureAwait(false);
            //await ijsrt.RemoveItem(tknKey);
            NotifyAuthenticationStateChanged(Task.FromResult(Anonimo));
        }
    }
}
