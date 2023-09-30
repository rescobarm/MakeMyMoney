using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Data
{
    public static class DataConf
    {
        //public static string HTTPClient = "httpDckrClient";"HTTPLapClientDkrWrk"
        public static string HTTPClient = "HTTPLapClientDkrWrk";
        public static string BaseAddressDckrWrkWiFi = "http://172.16.9.62:32771/";
        public static string _CnnStrng_SICAD_31 => CnnStrngLocal();
        public static string _CnnStrng_P3A_31 => CnnStrngLocal();

        //public static string _CnnStrng_SAC_31 => CnnStrng_SAC_Local();
        //public static string _CnnStrng_SAC_31 => CnnStrng_SAC_130();
        public static string _CnnStrng_SAC_31 => CnnStrngLocal();
        private static string CnnStrngLocal()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"127.0.0.1";
            sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        //public static string _CnnStrng_SICAD => CnnStrng_SICAD();
        //public static string _CnnStrng_SICAD => CnnStrng_SICAD_local();
        public static string _CnnStrng_SICAD => CnnStrng_SICAD_31();


        private static string CnnStrng_SICAD_31()
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

        private static string CnnStrng_SICAD_local()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"127.0.0.1";
            sqlConnectionStringBuilder.InitialCatalog = "SICAD_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        private static string CnnStrng_SICAD()
        {
            string serverName = "172.16.0.15";
            string instanceName = "WIN-MVQQD74KM80";
            string databaseName = "myDatabaseName";
            string userName = "sa";
            string password = "myPassword";
            int sqlServerVersion = 2008;
            //"Data Source=172.16.5.117; Initial Catalog=Serape; Persist Security Info = True;   User ID=sa;   Password=*SHyFP*Ch14p45*;";
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "172.16.5.117";
            //sqlConnectionStringBuilder.DataSource = $"{serverName}\\{instanceName}, {sqlServerVersion}";
            sqlConnectionStringBuilder.InitialCatalog = "SICAD_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*SHyFP*Ch14p45*";
            sqlConnectionStringBuilder.TrustServerCertificate = false;//true;
            sqlConnectionStringBuilder.Encrypt = false;
            return sqlConnectionStringBuilder.ConnectionString;
        }

		public static string _CnnStrng_SICAD_15 => CnnStrng_SICAD_Prdctn();
		private static string CnnStrng_SICAD_Prdctn()
		{
			string serverName = "172.16.0.15";
			string instanceName = "WIN-MVQQD74KM80";
			string databaseName = "SICAD_BD";
			string userName = "sa";
			string password = "*contralo%1";
			int sqlServerVersion = 2008;
			//"Data Source=172.16.5.117; Initial Catalog=Serape; Persist Security Info = True;   User ID=sa;   Password=*SHyFP*Ch14p45*;";
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
			sqlConnectionStringBuilder.DataSource = serverName;
			//sqlConnectionStringBuilder.DataSource = $"{serverName}\\{instanceName}, {sqlServerVersion}";
			sqlConnectionStringBuilder.InitialCatalog = databaseName;
			sqlConnectionStringBuilder.IntegratedSecurity = false;
			sqlConnectionStringBuilder.UserID = userName;
			sqlConnectionStringBuilder.Password = password;
			sqlConnectionStringBuilder.TrustServerCertificate = false;//true;
			sqlConnectionStringBuilder.Encrypt = false;
			return sqlConnectionStringBuilder.ConnectionString;
		}
		private static string CnnStrng_SICAD_()
        {
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            string dbName = Environment.GetEnvironmentVariable("DB_NAME");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            /*
              - DB_HOST=172.16.0.15
            - DB_PORT=1433
            - DB_NAME=SICAD_BD_PRUEBA
            - DB_USER=userDocker #${DB_USER}
            - DB_PASSWORD=rudyard #${DB_PASSWORD}
             */

            if (dbUser == null || dbPassword == null || dbUser == string.Empty || dbPassword == string.Empty)
                throw new Exception("Las credenciale para SICAD no se han establecido o no se han establecido corréctamente en el docker-compose, por favor verifica.");
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = dbHost; //@"172.16.0.15, 1433";
            sqlConnectionStringBuilder.InitialCatalog = dbName; // "SICAD_BD_PRUEBA";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = dbUser; //"userDocker";
            sqlConnectionStringBuilder.Password = dbPassword; // "rudyard";
            sqlConnectionStringBuilder.TrustServerCertificate = false;//true;
            sqlConnectionStringBuilder.Encrypt = false;
            //sqlConnectionStringBuilder.NetworkLibrary = "dbmssocn";
            //sqlConnectionStringBuilder["EnableTls1_2"] = "1";
            return sqlConnectionStringBuilder.ConnectionString;
        }
        private static string CnnStrng_P3A_31()
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
        private static string CnnStrng_SAC_31()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.5.31";
            sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*D3v3l0p3r*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        private static string CnnStrng_SAC_130()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.5.130";
            sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        private static string CnnStrng_SAC_Local()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = @"127.0.0.1";//172.18.0.3
            sqlConnectionStringBuilder.DataSource = @"172.17.0.2";//172.18.0.3
            sqlConnectionStringBuilder.InitialCatalog = "CDR_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
