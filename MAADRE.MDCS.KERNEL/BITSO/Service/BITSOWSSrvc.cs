using MAADRE.MDCSI.KERNEL.BITSO.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Polly;
using System.Web;

namespace MAADRE.MDCSI.KERNEL.BITSO.Service
{
    public interface IBITSOWSSrvc
    {
        /// <summary>
        /// GET https://sandbox.bitso.com/api/v3/open_orders/
        /// GET https://sandbox.bitso.com/api/v3/open_orders?book=btc_mxn
        /// </summary>
        /// <returns></returns>
        Task<ListOpenOrders> GetListOpenOrders(string symbol);
        /// <summary>
        /// GET https://sandbox.bitso.com/api/v3/order_trades/{oid}/
        /// GET https://sandbox.bitso.com/api/v3/order_trades?origin_id={origin_id}
        /// </summary>
        /// <returns></returns>
        Task<ListOrderTrades> GetListOrderTrades(string oid);
        /// <summary>
        /// GET https://sandbox.bitso.com/api/v3/user_trades/ 
        /// GET https://sandbox.bitso.com/api/v3/user_trades/{tid}/
        /// GET https://sandbox.bitso.com/api/v3/user_trades/{tid-tid-tid}/
        /// </summary>
        /// <returns></returns>
        Task<UserTrades> GetUserTrades();
        Task<AccountBalance> OnGetAccountBalance();
        //void SetTiker(CTiker ticker);
        Task<CTicker> GetTiker(string pair_coin);
        Task<string> PlaceOrder(object payload);
        Task GetOrderTrades(string oid);
    }
    public class BITSOWSSrvc : IBITSOWSSrvc
    {
        private readonly string _pk;
        private readonly string _sk;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly ILogger<BITSOWSSrvc> _logger;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;
        public enum METHOD
        {
            GET,
            Casado,
            Divorciado,
            Viudo
        }

        public BITSOWSSrvc(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public BITSOWSSrvc(IHttpClientFactory httpClientFactory, ILogger<BITSOWSSrvc> logger)
        {
            var publicKey = Environment.GetEnvironmentVariable("BITSO_PUBLIC_KEY");
            var privateKey = Environment.GetEnvironmentVariable("BITSO_SECRET_KEY");
            _pk = publicKey;
            _sk = privateKey;
            this._httpClientFactory = httpClientFactory;
            //this._httpClient = httpClientFactory.CreateClient("BITSOhttpClient");
            ////this._httpClient = httpClientFactory.CreateClient("HTTPSICADClientL");
            //this._httpClient.Timeout = TimeSpan.FromSeconds(90);
            this._asyncRetryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount: 15,
                intento => TimeSpan.FromSeconds(1 * intento),
                onRetry: (exeption, conteo, contexto) =>
                {
                    logger.LogInformation($" --- reintentando comunicarnos => ({DateTime.Now});");
                });
        }

        // GET https://sandbox.bitso.com/api/v3/open_orders?book=btc_mxn
        public async Task<ListOpenOrders> GetListOpenOrders(string symbol)
        {
            try
            {

                // Configurar la solicitud HTTP GET
                var request = await RequestAuth("GET", $"api/v3/open_orders/");

                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.SendAsync(request); //.GetAsync($"ticker/?book={pair_coin}");
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<object>();
                    var ut = JsonConvert.DeserializeObject<ListOpenOrders>(rcrds.ToString());
                    return ut == null ? new ListOpenOrders() : ut;
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET https://sandbox.bitso.com/api/v3/order_trades/{oid}/
        public async Task<ListOrderTrades> GetListOrderTrades(string oid)
        {
            try
            {
                
                // Configurar la solicitud HTTP GET
                var request = await RequestAuth("GET", $"api/v3/order_trades/{oid}/");

                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.SendAsync(request); //.GetAsync($"ticker/?book={pair_coin}");
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<object>();
                    var ut = JsonConvert.DeserializeObject<ListOrderTrades>(rcrds.ToString());
                    return ut == null ? new ListOrderTrades() : ut;
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<HttpRequestMessage> RequestAuth(string mETHOD, string pATCH)
        {
            var nonce = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            // Concatenar los valores
            //var message = $"{nonce}GET/api/v3/user_trades/";
            var message = $"{nonce}{mETHOD}/{pATCH}";
            // Crear el HMAC-SHA256
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_sk));
            var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            var signature = BitConverter.ToString(signatureBytes).Replace("-", string.Empty).ToLower();

            // Configurar el encabezado de autorización
            var authHeader = $"Bitso {_pk}:{nonce}:{signature}";

            // Configurar la solicitud HTTP GET
            var request = new HttpRequestMessage(HttpMethod.Get, $"/{pATCH}");
            request.Headers.Add("Authorization", authHeader);
            return await Task.FromResult(request);
        }

        public async Task<UserTrades> GetUserTrades()
        {
            try
            {
                // Generar el nonce
                var nonce = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                // Concatenar los valores
                var message = $"{nonce}GET/api/v3/user_trades/";
                // Crear el HMAC-SHA256
                var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_sk));
                var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                var signature = BitConverter.ToString(signatureBytes).Replace("-", string.Empty).ToLower();

                // Configurar el encabezado de autorización
                var authHeader = $"Bitso {_pk}:{nonce}:{signature}";

                // Configurar la solicitud HTTP GET
                var request = new HttpRequestMessage(HttpMethod.Get, "/api/v3/user_trades/");
                request.Headers.Add("Authorization", authHeader);

                // Enviar la solicitud
                // 

                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.SendAsync(request); //.GetAsync($"ticker/?book={pair_coin}");
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<object>();
                    var ut = JsonConvert.DeserializeObject<UserTrades>(rcrds.ToString());
                    return ut == null ? new UserTrades() : ut;
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<object>> ListUserTrades()
        {
            try
            {
                string path = "/v3/user_trades/";
                string httpMethod = "GET";
                string queryString = "";
                string payload = "";
                string nonce = MakeNonce();

                string message = nonce + httpMethod + path + queryString + payload;
                string signature = SignMessage(message, _sk);

                using (HttpClient httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bitso {_pk}:{nonce}:{signature}");

                    var httpResponse = await _asyncRetryPolicy.ExecuteAsync(async () =>
                    {
                        var response = await httpClient.GetAsync(path);
                        if (response.IsSuccessStatusCode)
                        {
                            return response;
                        }
                        return response;
                    });

                    httpResponse.EnsureSuccessStatusCode();

                    var responseBody = await httpResponse.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<object>>(responseBody);
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string SignMessage(string message, string secret)
        {
            byte[] keyBytes = Convert.FromBase64String(secret);
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);

            using (var hmacsha256 = new System.Security.Cryptography.HMACSHA256(keyBytes))
            {
                byte[] hash = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hash);
            }
        }
        private string MakeNonce()
        {
            long unixTimestampMilliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            return unixTimestampMilliseconds.ToString();
        }


        #region ListOrderTrades

        /// <summary>
        /// List Order Trades
        /// Enumerar transacciones de pedidos 
        /// Alguna vez funcionó, pero ya no
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        /// <exception cref="WebException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task GetOrderTrades_resp(string oid)
        {
            try
            {
                var some = await ListUserTrades();
                /***********************/
                //string path = $"v3/order_trades?origin_id={oid}";
                //string path = $"/v3/trades/?book={HttpUtility.UrlEncode("btc_mxn")}&limit={25}&offset={0}";
                //string path = "api/v3/fees/";
                string path = "https://api.bitso.com" + "/api/v3/fees/";
                //$"api/v3/orders/{oid}/";
                string httpMethod = "GET";
                string queryString = "";
                string payload = "";
                string nonce = MakeNonce();
                //string message = nonce + httpMethod + path + queryString + payload;
                string message = nonce + httpMethod + path;
                string signature = SignMessage(message, _sk);
                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    //0httpClient.DefaultRequestHeaders.Add("Authorization", $"Bitso {_pk}:{nonce}:{signature}");
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.GetAsync(path);
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<CTicker>();
                    //return rcrds;
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task GetOrderTrades(string oid)
        {
            string path = "https://api.bitso.com/api/v3" + $"/order_trades/{oid}";
            string requestPath = $"/api/v3/order_trades/{oid}";
            string nonce = MakeNonce();
            string httpMethod = "GET";

            //string jsonPayload = JsonConvert.SerializeObject(payload);

            var oid1 = await PostOrder1(nonce, path, requestPath, httpMethod, oid);
            if (oid1.success)
            {
                //payload.Id = oid.payload.oid;
                //await _cntx.TTrade.AddAsync(payload);
                //await _cntx.SaveChangesAsync();
                //return oid1.payload.oid;
            }
            //return "nell";
        }
        public async Task<RootPostOrderBack> PostOrder1(string nonce, string path, string requestPath, string httpMethod, string jsonPayload)
        {
            try
            {
                string message = nonce + httpMethod + requestPath; //+ jsonPayload;
                byte[] secretBytes = Encoding.UTF8.GetBytes(_sk);
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                string signature;
                using (var hmac = new HMACSHA256(secretBytes))
                {
                    byte[] signatureBytes = hmac.ComputeHash(messageBytes);
                    signature = BitConverter.ToString(signatureBytes).Replace("-", string.Empty).ToLower();
                }

                string authHeader = $"Bitso {_pk}:{nonce}:{signature}";

                var result = await UrlRequestAsync1(path, httpMethod, jsonPayload, authHeader);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private async Task<RootPostOrderBack> UrlRequestAsync1(string path, string httpMethod, string jsonPayload, string authHeader)
        {
            try
            {
                //var cp = $"{path}{jsonPayload}";
                var request = new HttpRequestMessage(new HttpMethod(httpMethod), path);
                request.Headers.Add("Authorization", authHeader);
                //request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var sr = await response.Content.ReadFromJsonAsync<RootPostOrderBack>();

                //if (sr.success)
                //{
                //    return sr.payload.oid;
                //}
                return sr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion ListOrderTrades

        #region GET->TICKER
        public async Task<CTicker> GetTiker(string pair_coin)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.GetAsync($"ticker/?book={pair_coin}");
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<CTicker>();
                    return rcrds == null ? new CTicker() : rcrds;
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message, ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion GET->TICKER

        #region POST->ORDER
        public async Task<string> PlaceOrder(object payload)
        {
            string path = "https://api.bitso.com/api/v3" + "/orders/";
            string requestPath = "/api/v3/orders/";
            string nonce = MakeNonce();
            string httpMethod = "POST";

            string jsonPayload = JsonConvert.SerializeObject(payload);

            var oid = await PostOrder(nonce, path, requestPath, httpMethod, jsonPayload);
            if (oid.success)
            {
                //payload.Id = oid.payload.oid;
                //await _cntx.TTrade.AddAsync(payload);
                //await _cntx.SaveChangesAsync();
                return oid.payload.oid;
            }
            return "nell";
        }
        public async Task<RootPostOrderBack> PostOrder(string nonce, string path, string requestPath, string httpMethod, string jsonPayload)
        {
            try
            {
                string message = nonce + httpMethod + requestPath + jsonPayload;
                byte[] secretBytes = Encoding.UTF8.GetBytes(_sk);
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                string signature;
                using (var hmac = new HMACSHA256(secretBytes))
                {
                    byte[] signatureBytes = hmac.ComputeHash(messageBytes);
                    signature = BitConverter.ToString(signatureBytes).Replace("-", string.Empty).ToLower();
                }

                string authHeader = $"Bitso {_pk}:{nonce}:{signature}";

                var result = await UrlRequestAsync(path, httpMethod, jsonPayload, authHeader);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private async Task<RootPostOrderBack> UrlRequestAsync(string path, string httpMethod, string jsonPayload, string authHeader)
        {
            try
            {
                //var cp = $"{path}{jsonPayload}";
                var request = new HttpRequestMessage(new HttpMethod(httpMethod), path);
                request.Headers.Add("Authorization", authHeader);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var sr = await response.Content.ReadFromJsonAsync<RootPostOrderBack>();

                //if (sr.success)
                //{
                //    return sr.payload.oid;
                //}
                return sr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion POST->ORDER

        #region GET->ACCOUNT-BALANCE
        public async Task<AccountBalance> OnGetAccountBalance()
        {
            try
            {
                // Generar el nonce
                var nonce = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                // Concatenar los valores
                var message = $"{nonce}GET/api/v3/balance/";
                // Crear el HMAC-SHA256
                var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_sk));
                var signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                var signature = BitConverter.ToString(signatureBytes).Replace("-", string.Empty).ToLower();

                // Configurar el encabezado de autorización
                var authHeader = $"Bitso {_pk}:{nonce}:{signature}";

                // Configurar la solicitud HTTP GET
                var request = new HttpRequestMessage(HttpMethod.Get, "/api/v3/balance/");
                request.Headers.Add("Authorization", authHeader);

                // Enviar la solicitud
                // 

                using (var httpClient = _httpClientFactory.CreateClient("BITSOhttpClient"))
                {
                    var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                        var rspns = await httpClient.SendAsync(request); //.GetAsync($"ticker/?book={pair_coin}");
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    });
                    httpRspns.EnsureSuccessStatusCode();
                    var rcrds = await httpRspns.Content.ReadFromJsonAsync<AccountBalance>();
                    return rcrds == null ? new AccountBalance() : rcrds;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion GET->ACCOUNT-BALANCE
    }
}
