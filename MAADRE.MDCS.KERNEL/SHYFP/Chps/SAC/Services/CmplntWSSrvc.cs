using MAADRE.MDCSI.KERNEL.Globals.Data;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Services
{
    public interface ICmplntWSSrvc
    {
        Task<IEnumerable<CCmbBxOptns>> GetGobAgency(string opt);
    }
    public class CmplntWSSrvc : ICmplntWSSrvc
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

        public CmplntWSSrvc(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _asyncRetryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount: 15,
                intento => TimeSpan.FromSeconds(1 * intento),
                onRetry: (exeption, conteo, contexto) =>
                {
                    //logger.LogInformation($" --- reintentando comunicarnos => ({DateTime.Now});");
                });
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetGobAgency(string opt)
        {
            try
            {
                CCtlgOptns co = new CCtlgOptns {
                    ce = "", opt= opt
                };
                var js = System.Text.Json.JsonSerializer.Serialize(co);
                var jsonContent = new StringContent(js, Encoding.UTF8, "application/json");
                var httpRspns = await _asyncRetryPolicy.ExecuteAsync(async () => {
                    using(var httpClient  = _httpClientFactory.CreateClient(DataConf.HTTPClient))
                    {
                        var rspns = await httpClient.PostAsync($"api/PblcCmplnt/GetCtlg", jsonContent);
                        if (rspns.IsSuccessStatusCode)
                        {
                            var rslt = rspns.Content.ReadAsStringAsync().Result;
                            return rspns;
                        }
                        return rspns;
                    }
                    
                    //return await httpClient.PostAsJsonAsync("api/JWTAuth/GETAuthJWT", oUI);
                });
                httpRspns.EnsureSuccessStatusCode();
                var rcrds = await httpRspns.Content.ReadFromJsonAsync<IEnumerable<CCmbBxOptns>>();
                return rcrds;
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
    }
}
