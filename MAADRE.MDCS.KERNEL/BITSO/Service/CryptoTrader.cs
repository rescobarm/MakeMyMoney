using MAADRE.MDCSI.KERNEL.BITSO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Service
{
	public class CryptoTrader
	{
		private readonly ICryptoApi _api;
		private readonly IBrokerApi _broker;
		private CancellationTokenSource _cts;
		private decimal _lastPrice;

		public CryptoTrader(ICryptoApi api, IBrokerApi broker)
		{
			_api = api;
			_broker = broker;
		}

		public async Task StartTrading(string symbol, decimal targetPrice, bool isBuyOrder)
		{
			_cts = new CancellationTokenSource();

			// 1.- Realizar una función en segundo plano que devuelva el precio de determinada criptomoneda.
			var priceTask = Task.Run(async () =>
			{
				while (!_cts.IsCancellationRequested)
				{
					_lastPrice = await _api.GetPrice(symbol);
					Console.WriteLine($"Current price for {symbol}: {_lastPrice}");
					await Task.Delay(TimeSpan.FromSeconds(5));
				}
			}, _cts.Token);

			// 2.- Realizar una función que ponga una orden de compra o de venta según se le sea indicado, y que espere hasta que dicha orden sea colocada.
			var orderTask = Task.Run(async () =>
			{
				while (!_cts.IsCancellationRequested)
				{
					string orderType = isBuyOrder ? "Buy" : "Sell";
					Console.WriteLine($"Placing {orderType} order for {symbol} at {targetPrice}");
					string orderId = await _broker.PlaceOrder(symbol, targetPrice, isBuyOrder);

					// 3.- Realizar un proceso que esté pendiente hasta que la orden sea ejecutada en el broker.
					while (!_cts.IsCancellationRequested)
					{
						string orderStatus = await _broker.GetOrderStatus(orderId);
						Console.WriteLine($"Order {orderId} status: {orderStatus}");
						if (orderStatus == "Filled")
						{
							Console.WriteLine($"Order {orderId} filled at {targetPrice}");
							return;
						}
						await Task.Delay(TimeSpan.FromSeconds(5));
					}
				}
			}, _cts.Token);

			await Task.WhenAny(priceTask, orderTask);
			_cts.Cancel();
		}

		public void StopTrading()
		{
			_cts?.Cancel();
		}
	}
}
