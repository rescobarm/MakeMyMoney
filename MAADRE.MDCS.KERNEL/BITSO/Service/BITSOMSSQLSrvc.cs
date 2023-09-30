using MAADRE.MDCSI.KERNEL.BITSO.Data;
using MAADRE.MDCSI.KERNEL.BITSO.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Service
{
    public interface IBITSOMSSQLSrvc
    {
        Task<TradeBuy> GetData();
    }
    public class BITSOMSSQLSrvc : IBITSOMSSQLSrvc
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private TradeBuy? _unCompletedTrade;

        public BITSOMSSQLSrvc(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            //UseDb().Wait();
        }

        async Task UseDb()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContextFactory = scope.ServiceProvider.GetRequiredService<ISQLBitsoCntxFactory>();
                var dbContext = dbContextFactory.Create();

                // Utiliza el dbContext dentro del ámbito creado
                // ...
                //_unCompletedTrade = dbContext.TTradeBuy.FirstOrDefault<TradeBuy>();

                // Finaliza y elimina el dbContext al finalizar el ámbito
                await dbContext.DisposeAsync();
            }
        }

        public async Task<TradeBuy> GetData()
        {
            try
            {
                return null;
                //using (var scope = _serviceScopeFactory.CreateScope())
                //{
                //    var dbContextFactory = scope.ServiceProvider.GetRequiredService<ISQLBitsoCntxFactory>();
                //    var dbContext = dbContextFactory.Create();

                //    // Utiliza el dbContext dentro del ámbito creado
                //    // ...
                //    var bt = dbContext.TTradeBuy.FirstOrDefault<TradeBuy>();

                //    // Finaliza y elimina el dbContext al finalizar el ámbito
                //    await dbContext.DisposeAsync();
                //    return bt;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
