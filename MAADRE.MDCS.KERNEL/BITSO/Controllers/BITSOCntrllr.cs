using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAADRE.MDCSI.KERNEL.BITSO.Models;
using MAADRE.MDCSI.KERNEL.BITSO.Data;
using Microsoft.Extensions.DependencyInjection;
using MAADRE.MDCSI.KERNEL.BITSO.Service;

namespace MAADRE.MDCSI.KERNEL.BITSO.Controllers
{

    namespace MAADRE.MDCSI.KERNEL.BITSO.Controllers
    {

        public interface IBITSOCntrllr
        {
            Task<ListOpenOrders> GetListOpenOrders(string symbol);
            Task<ListOrderTrades> GetListOrderTrades(string oid);
            Task<UserTrades> GetUserTrades();
            Task<AccountBalance> OnGetAccountBalance();
            void SetTiker(CTicker ticker);
            IList<CTicker> OTickers { get; set; }
            Task GetOrderTrades(string oid);
            Task<string> PlaceOrder(object order);
            Task<CTicker> GetTiker(string pair_coin);
        }
        public class BITSOCntrllr : IBITSOCntrllr
        {
            private readonly ISQLBitsoCntxFactory _dbContextFactory;
            private readonly IServiceScopeFactory _serviceScopeFactory;
            private readonly IBITSOMSSQLSrvc _dbCntx;
            private readonly IBITSOWSSrvc _ibwss;
            TradeBuy unCompletedTrade;

            public async Task<UserTrades> GetUserTrades()
            {
                try
                {
                    var ab = await _ibwss.GetUserTrades();
                    return ab;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            public async Task<AccountBalance> OnGetAccountBalance()
            {
                try
                {
                    var ab = await _ibwss.OnGetAccountBalance();
                    return ab;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }

            public BITSOCntrllr(IBITSOWSSrvc ibwss)
            {
                _ibwss = ibwss;
            }
            public async Task<CTicker> GetTiker(string pair_coin)
            {
                return await _ibwss.GetTiker(pair_coin);
            }

            public BITSOCntrllr(IBITSOMSSQLSrvc dbCntx, IBITSOWSSrvc ibwss)
            {
                //_serviceScopeFactory = serviceScopeFactory;
                _dbCntx = dbCntx;
                _ibwss = ibwss;
                //UseDb().Wait();
                SetUT();
            }

            async void SetUT()
            {
                unCompletedTrade = await _dbCntx.GetData();
            }


            
            public async Task<string> PlaceOrder(object order)
            {
                if (order is TradeBuy b)
                {
                    var oid = await _ibwss.PlaceOrder(b);
                    return await Task.FromResult(oid);
                }
                if (order is TradeSell s)
                {
                    var oid = await _ibwss.PlaceOrder(s);
                    return await Task.FromResult(oid);
                }
                return await Task.FromResult("nell");
            }


            private const int MaxItems = 100;
            public IList<CTicker> OTickers { get; set; } = new List<CTicker>();
            private Queue<CTicker> insertionOrder = new Queue<CTicker>();
            int i = 0;
            public void SetTiker(CTicker ticker)
            {
                OTickers.Add(ticker);
                insertionOrder.Enqueue(ticker);

                if (insertionOrder.Count > MaxItems)
                {
                    // Eliminamos el primer elemento agregado cuando se supera el límite
                    var tickerToRemove = insertionOrder.Dequeue();
                    OTickers.Remove(tickerToRemove);
                }
            }
            public async Task GetOrderTrades(string oid)
            {
                await _ibwss.GetOrderTrades(oid);
            }

            public async Task<ListOrderTrades> GetListOrderTrades(string oid)
            {
                var lot = await _ibwss.GetListOrderTrades(oid);
                return lot;
            }

            public async Task<ListOpenOrders> GetListOpenOrders(string symbol)
            {
                var loo = await _ibwss.GetListOpenOrders(symbol);
                return loo;
            }
        }
    }
}
