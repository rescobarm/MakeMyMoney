using MAADRE.MDCSI.KERNEL.BITSO.Models;
using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Service
{
    public class TiketSrvc1 : IHostedService, IDisposable
    {
        private Timer _timer;
        //private readonly ILogger _logger;
        int i = 0;
        private readonly IWSrvc<CTiker> _tkr;

        public TiketSrvc1(IWSrvc<CTiker> tkr)
        {
            _tkr = tkr;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._timer = new Timer(GetTicket, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
            return Task.CompletedTask;
        }
        public async void GetTicket(object state) 
        {
            Console.Clear();
            //Console.WriteLine($"Contando i[{i++}]");
            var tikers = await _tkr.GetAll("btc_mxn");
            Console.WriteLine(JsonSerializer.Serialize(tikers));
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

	public class TicketSrvc : IHostedService, IDisposable
	{
		private readonly IWSrvc<CTiker> _tkr;
		private CancellationTokenSource _cancellationTokenSource;
		private readonly ILogger<TicketSrvc> _logger;

		public TicketSrvc(IWSrvc<CTiker> tkr, ILogger<TicketSrvc> logger)
		{
			_tkr = tkr;
			_logger = logger;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			_cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
			await Task.Run(async () => await ExecuteAsync(_cancellationTokenSource.Token), cancellationToken);
		}

		private async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					var tikers = await _tkr.GetAll("btc_mxn");
					_logger.LogInformation(JsonSerializer.Serialize(tikers));
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error al obtener los tickets.");
				}

				await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
			}
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_cancellationTokenSource?.Cancel();
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			_cancellationTokenSource?.Dispose();
		}
	}
}
