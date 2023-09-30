using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Services
{
    public class CWSrvc<T> : IWSrvc<T>, IDisposable
    {
        private readonly IHttpClientFactory _httpCF;

        private readonly HttpClient _httpClient;
        private readonly string _bah = "some";
        protected string? Nonce { get; set; }
        protected string _key;
        protected string _secret;
        protected string _url = "https://api.bitso.com/";
        public CWSrvc(IHttpClientFactory httpClientFactory) 
        {
            this._httpCF = httpClientFactory;//.CreateClient("ConfiguredHttpMessageHandler");
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Auth_Header", this._bah);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            this.Dispose();
        }

        public async Task<T> GetAll(string byParm)
        {
            try
            {
                object? lstUsers = null;
                // Call the method Get
                var responseService = await _httpClient.GetAsync($"v3/ticker/?book={byParm}");
                if (responseService.IsSuccessStatusCode)
                {
                    // Read the list of Users
                    var outputService = await responseService.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    try
                    {
                        // Deserialization of the output
                        lstUsers = JsonSerializer.Deserialize<T>(outputService, options);
                    }
                    catch
                    {
                        throw;
                    }
                }

                return (T)lstUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetAll()
        {
            try
            {
                object lstUsers = null;
                // Call the method Get
                var responseService = await _httpCF.CreateClient().GetAsync("https://api.bitso.com/v3/ticker/");
                if (responseService.IsSuccessStatusCode)
                {
                    // Read the list of Users
                    var outputService = await responseService.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    try
                    {
                        // Deserialization of the output
                        lstUsers = JsonSerializer.Deserialize<T>(outputService, options);
                    }
                    catch
                    {
                        throw;
                    }
                }

                return (T)lstUsers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
