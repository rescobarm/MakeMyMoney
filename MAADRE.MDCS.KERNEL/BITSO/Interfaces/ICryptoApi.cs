using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Interfaces
{
	public interface ICryptoApi
	{
		Task<decimal> GetCryptoPriceAsync(string cryptoSymbol);
		Task<decimal> GetPrice(string symbol);
	}

	public interface IBrokerApi
	{
		Task PlaceOrderAsync(string symbol, decimal price, int quantity, OrderType type);
		Task<OrderStatus> CheckOrderStatusAsync(int orderId);
		Task<string> GetOrderStatus(object orderId);
		Task<string> PlaceOrder(string symbol, decimal targetPrice, bool isBuyOrder);
	}

	public enum OrderType
	{
		Buy,
		Sell
	}

	public enum OrderStatus
	{
		Pending,
		Filled,
		Cancelled
	}
}
