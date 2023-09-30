using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Data
{
    public class KRDXSQLCntx : DbContext
    {
        private readonly DbContextOptions<KRDXSQLCntx> _opt;
        private readonly IConfiguration _conf;

        static public string _strCnnP3A => CnnP3ALocalS();
        static public string _strCnnSICAD => CnnSICADLocalS();
        //CnnSICAD_Prdctn();
        //CnnP3ALocalS();
        public KRDXSQLCntx(DbContextOptions<KRDXSQLCntx> opt, IConfiguration conf) : base(opt)
        {
            _opt = opt;
            _conf = conf;
        }
        //"Data Source=172.16.5.31;Initial Catalog=SICAD_BD;Integrated Security=False;User ID=sa;Password=*D3v3l0p3r*";
        static string CnnSICADLocalS()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.5.31";
            sqlConnectionStringBuilder.InitialCatalog = "SICAD_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*D3v3l0p3r*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        static string CnnP3ALocalS()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.5.31";
            sqlConnectionStringBuilder.InitialCatalog = "P3A_DB";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*D3v3l0p3r*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        static string CnnSICAD_Prdctn()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.0.15";
            sqlConnectionStringBuilder.InitialCatalog = "SICAD_BD_PRUEBA";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*contralo%1";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
