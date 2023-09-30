using MAADRE.MDCSI.KERNEL.BITSO.Models;
using Microsoft.Extensions.Logging;
using Pipelines.Sockets.Unofficial.Arenas;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Service
{
    public interface IBITSOTickerSrvc {
        Task<CTiker> GetCTiker(string symbol);
    }
    public class BITSOTickerSrvc : IBITSOTickerSrvc
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _asyncRetryPolicy;

        public BITSOTickerSrvc(IHttpClientFactory _httpClientFactory, ILogger<BITSOTickerSrvc> logger)
        {
            this._httpClientFactory = _httpClientFactory;
            this._httpClient = _httpClientFactory.CreateClient("MyHttpClientTest");
            this._httpClient.Timeout = TimeSpan.FromSeconds(90);
            this._asyncRetryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount: 15,
                intento => TimeSpan.FromSeconds(1 * intento),
                onRetry: (exeption, conteo, contexto) =>
                {
                    logger.LogInformation($" --- reintentando comunicarnos => ({DateTime.Now});");
                });
        }
        public async Task<CTiker> GetCTiker(string symbol)
        {
            try
            {

                return await Task.FromResult(new CTiker { });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
