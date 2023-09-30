using MakeMyMoney.MAADRESystem.Globals.Models;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace MakeMyMoney.MAADRESystem.Globals.Data.WebServices
{
    public interface IUserFireBaseWSSrvc
    {
        Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials);
    }
    public class UserFireBaseWSSrvc : IUserFireBaseWSSrvc
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserFireBaseWSSrvc> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

        public UserFireBaseWSSrvc(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
            this._asyncRetryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount: 15,
                intento => TimeSpan.FromSeconds(1 * intento),
                onRetry: (exeption, conteo, contexto) =>
                {
                    _logger.LogInformation($" --- reintentando comunicarnos => ({DateTime.Now});");
                });
        }

        public async Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials)
        {
            string url = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyAChEYRW23xztmqoDFhX2E2xV_dp_MRpxo";

            var js = System.Text.Json.JsonSerializer.Serialize(userCredentials);
            var jsonContent = new StringContent(js, Encoding.UTF8, "application/json");

            using (var httpClient = this._httpClientFactory.CreateClient())
            {
                var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () =>
                {
                    var rspns = await httpClient.PostAsync(url, jsonContent);
                    if (!rspns.IsSuccessStatusCode)
                    {
                        // Not sure if you really want to just return the response if not successful.
                        // Usually, you would handle the error here.
                        return rspns;
                    }
                    return rspns;
                });

                httpRspns.EnsureSuccessStatusCode();
                return await httpRspns.Content.ReadFromJsonAsync<SignUpUserCredentialsResponse>();
            }
        }
    }
}
