using MakeMyMoney.MAADRESystem.Globals.Cntrlls;
using MakeMyMoney.MAADRESystem.Globals.Models;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MakeMyMoney.MAADRESystem.Globals.Data.WebServices
{
    public interface IUserFireBaseWSSrvc
    {
        Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials);
    }
    public class UserFireBaseWSSrvc : IUserFireBaseWSSrvc
    {
        private readonly string _fbKey;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<UserFireBaseWSSrvc> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

        public UserFireBaseWSSrvc(ILogger<UserFireBaseWSSrvc> logger, 
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _fbKey = configuration["FirebaseKey"];
            _logger = logger;
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
            var url = $"v1/accounts:signUp?key={_fbKey}";
            var httpClient = _httpClientFactory.CreateClient("HTTPCFirebase");

            var jsonContent = new StringContent(JsonSerializer.Serialize(userCredentials), Encoding.UTF8, "application/json");

            try
            {
                var httpResponse = await _asyncRetryPolicy.ExecuteAsync(async () =>
                {
                    var response = await httpClient.PostAsync(url, jsonContent);
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new DoNotRetryException("Unauthorized");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {

                        throw new DoNotRetryException("BadRequest");
                    }
                    response.EnsureSuccessStatusCode();  // Esto lanzará una excepción si el código de estado no es exitoso.
                    return response;
                });

                return await httpResponse.Content.ReadFromJsonAsync<SignUpUserCredentialsResponse>();
            }
            catch (DoNotRetryException ex)
            {
                _logger.LogError(ex, $"Unauthorized error during sign up. URL: {url}");
                // Manejar la excepción no autorizada según sea necesario.
                throw;
            }
            catch (HttpRequestException ex)  // Capturar excepciones específicas antes que Exception.
            {
                _logger.LogError(ex, $"Error during sign up. URL: {url}");
                throw;  // Relanzar la excepción original.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error during sign up. URL: {url}");
                throw;  // Relanzar la excepción original.
            }
        }

    }
}
