using MAADRE.MDCSI.KERNEL.Globals.Controllers;
using MAADRE.MDCSI.KERNEL.Globals.Models;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Services
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
            this._httpClientFactory = httpClientFactory;//.CreateClient("ConfiguredHttpMessageHandler");
            this._httpClientFactory = httpClientFactory;
            //this._httpClient = httpClientFactory.CreateClient("HTTPSICADClient");
            ////this._httpClient = httpClientFactory.CreateClient("HTTPSICADClientL");
            //this._httpClient.Timeout = TimeSpan.FromSeconds(90);
            this._asyncRetryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount: 15,
                intento => TimeSpan.FromSeconds(1 * intento),
                onRetry: (exeption, conteo, contexto) =>
                {
                    _logger.LogInformation($" --- reintentando comunicarnos => ({DateTime.Now});");
                });
            //_httpClient = httpClientFactory.CreateClient();
            //_httpClient.BaseAddress = new Uri(_url);
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Add("Auth_Header", this._bah);
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        //public async Task<SignUpUserCredentialsResponse> SignUpAsync(UserCredentials userCredentials)
        //{
        //    try
        //    {
        //        string url = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyAChEYRW23xztmqoDFhX2E2xV_dp_MRpxo";

        //        var js = System.Text.Json.JsonSerializer.Serialize(userCredentials);
        //        var jsonContent = new StringContent(js, Encoding.UTF8, "application/json");
        //        var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
        //            var _httpClient = this._httpClientFactory.CreateClient();
        //            var rspns = await _httpClient.PostAsync(url, jsonContent);
        //            //var rspns = await _httpClient.PostAsync($"api/JWTAuth/GetAttndncChck", jsonContent);
        //            if (rspns.IsSuccessStatusCode)
        //            {
        //                var rslt = rspns.Content.ReadAsStringAsync().Result;
        //                return rspns;
        //            }
        //            return rspns;
        //            //return await httpClient.PostAsJsonAsync("api/JWTAuth/GETAuthJWT", oUI);
        //        });
        //        httpRspns.EnsureSuccessStatusCode();
        //        var rcrds = await httpRspns.Content.ReadFromJsonAsync<SignUpUserCredentialsResponse>();
        //        return rcrds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
//// Define el objeto que quieres enviar como cuerpo de la solicitud POST
//var requestData = userCredentials;

//// Serializa el objeto a una cadena JSON
//var jsonContent = JsonSerializer.Serialize(requestData);

//// Convierte la cadena JSON en un contenido Http
//var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

//using (var httpClient = new HttpClient())
//{
//    // Realiza la solicitud POST
//    var httpResponse = await httpClient.PostAsync(url, httpContent);

//    // Si la solicitud no tuvo éxito, lanza una excepción
//    httpResponse.EnsureSuccessStatusCode();

//    // Lee y deserializa la respuesta
//    var responseContent = await httpResponse.Content.ReadAsStringAsync();
//    var responseObj = JsonSerializer.Deserialize<SignUpUserCredentialsResponse>(responseContent);
//    return responseObj;
//}