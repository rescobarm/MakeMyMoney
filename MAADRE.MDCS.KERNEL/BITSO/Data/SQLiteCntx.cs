using MAADRE.MDCSI.KERNEL.BITSO.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Sqlite; //¿¿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Data
{
	class SQLiteCntx : DbContext
	{
		private readonly string connectionString;

		public SQLiteCntx(string connectionString)
		{
			this.connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlite(new SqliteConnection(connectionString));
		}

		public DbSet<AccountBalance> AccountBalance { get; set; }
	}
}
