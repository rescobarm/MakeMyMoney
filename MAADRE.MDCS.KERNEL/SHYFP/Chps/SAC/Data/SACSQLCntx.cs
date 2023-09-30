using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Data
{
    public class SACSQLCntx : DbContext
    {
        private readonly DbContextOptions<SACSQLCntx> _opt;
        private readonly IConfiguration _conf;
        static public string _strCnn => CnnStrngLocal();

        public SACSQLCntx(DbContextOptions<SACSQLCntx> opt, IConfiguration conf) : base(opt)
        {
            _opt = opt;
            _conf = conf;
        }

        private static string CnnStrngLocal()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.9.62";
            sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        //static string CnnSACLocalS()
        //{
        //    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        //    sqlConnectionStringBuilder.DataSource = @"172.16.5.31";
        //    sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
        //    sqlConnectionStringBuilder.IntegratedSecurity = false;
        //    sqlConnectionStringBuilder.UserID = "sa";
        //    sqlConnectionStringBuilder.Password = "*D3v3l0p3r*";
        //    sqlConnectionStringBuilder.TrustServerCertificate = true;
        //    return sqlConnectionStringBuilder.ConnectionString;
        //}
    }
}
