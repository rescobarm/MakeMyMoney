using MAADRE.MDCSI.KERNEL.BITSO.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Data
{
    public interface ISQLBitsoCntxFactory
    {
        SQLBitsoCntx Create();
    }

    public class SQLBitsoCntxFactory : ISQLBitsoCntxFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SQLBitsoCntxFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public SQLBitsoCntx Create()
        {
            var dbContextOptions = _serviceProvider.GetRequiredService<DbContextOptions<SQLBitsoCntx>>();
            var configuration = _serviceProvider.GetRequiredService<IConfiguration>();

            return new SQLBitsoCntx(dbContextOptions, configuration);
        }
    }
    /*************************************************************/
    public class SQLBitsoCntx : DbContext
    {
        private readonly DbContextOptions<SQLBitsoCntx> _opt;
        private readonly IConfiguration _conf;
        static public string _strCnnLocal => CnnStrngLocal();

        public SQLBitsoCntx(DbContextOptions<SQLBitsoCntx> opt, IConfiguration conf) : base(opt)
        {
            _opt = opt;
            _conf = conf;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_strCnnLocal);
            base.OnConfiguring(optionsBuilder);
        }
        private static string CnnStrngLocal()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"127.0.0.1";
            sqlConnectionStringBuilder.InitialCatalog = "DB_Bitso";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        public DbSet<TradeBuy> TTradeBuy { get; set; }
        public DbSet<TradeSell> TTradeSell { get; set; }
        public DbSet<AccountBalance> TAccountBalance { get; set; }
    }
}
