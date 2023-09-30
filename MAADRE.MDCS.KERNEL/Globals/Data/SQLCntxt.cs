using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace MAADRE.MDCSI.KERNEL.Globals.Data
{
    public class SQLCntx : IdentityDbContext<CUser, CRole, string,
        IdentityUserClaim<string>, CUserRole, CUserLogin,
        IdentityRoleClaim<string>, CUserToken>
    {
        private readonly DbContextOptions<SQLCntx> _opt;
        private readonly IConfiguration _conf;

        static public string _strCnnLocal => CnnStrngLocalW();
        static public string _strCnnSrvr_130 = CnnStrngSrvr_130();
        static public string _strCnn => CnnStrng();

        //CnnSICAD_Prdctn();
        //CnnP3ALocalS();
        public SQLCntx(DbContextOptions<SQLCntx> opt, IConfiguration conf) : base(opt)
        {
            _opt = opt;
            _conf = conf;
        }
        public DbSet<CUser> TUser { get; set; }
        public DbSet<CRole> CRole { get; set; }
        public DbSet<CUserRole> DUserRole { get; set; }
        public DbSet<CMenu> CMenu { get; set; }
        public DbSet<CUserMenu> DUserMenu { get; set; }
        public DbSet<VMenu> VUserMenus { get; set; }
        public DbSet<VUserRole> VUserRole { get; set; }
        public DbSet<CProject> TProjects { get; set; }
        public DbSet<COrganisms> TOrganisms { get; set; }
        public DbSet<DUserOrganism> DUserOrganism { get; set; }
        public DbSet<CClassifications> CClassifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_strCnnSrvr_130);
            //optionsBuilder.UseSqlServer($@"Data Source=DESKTOP-FPA4P34\SQLEXPRESS;
            //    Initial Catalog={dbName}; Integrated Security=True;
            //    Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
            //    ApplicationIntent=ReadWrite;MultiSubnetFailover=False;",
            //    m => m.MigrationsAssembly("INDEX.BLAZOR.KERNEL"));
            //optionsBuilder.UseMySQL("server=localhost; user=root; database=bd_test_00; password=rudyard9; port=3306;");
            //UseMySQL

            //optionsBuilder.UseSqlServer($@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog={dbName}; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;", m => m.MigrationsAssembly("INDEX.BLAZOR.KERNEL"));

            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;", m => m.MigrationsAssembly("INDEX.BLAZOR.KERNEL"));
            //optionsBuilder.UseSqlServer("Server=localhost;Database=MSSQLDbContext01;Trusted_Connection=True;", m => m.MigrationsAssembly("INDEX.BLAZOR.KERNEL"));
            base.OnConfiguring(optionsBuilder);
        }
        
        private static string CnnStrngLocal()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"127.0.0.1";
            sqlConnectionStringBuilder.InitialCatalog = "DB_Cntx";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
        private static string CnnStrngLocalW()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.9.62";
            sqlConnectionStringBuilder.InitialCatalog = "DB_Cntx";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        private static string CnnStrngSrvr_130()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.5.130";
            sqlConnectionStringBuilder.InitialCatalog = "DB_Cntx";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*Rudyard*1979*";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }

        private static string CnnStrng()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"172.16.0.15";
            sqlConnectionStringBuilder.InitialCatalog = "SICAD_BD";
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "*contralo%1";
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
