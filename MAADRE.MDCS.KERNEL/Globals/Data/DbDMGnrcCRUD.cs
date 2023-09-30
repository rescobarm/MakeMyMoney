using Dapper;
using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Data
{
    public class DbDMGnrcCRUD<T> : IDbDMGnrcCRUD<T>
    {
        readonly string cnnStr = string.Empty;
        public DbDMGnrcCRUD() { }
        public DbDMGnrcCRUD(string str)
        {
            cnnStr = str;
        }
		/***************/
		public async Task<IEnumerable<T>> GetQryCllctnDataAync_sicdb(string byQuery, object prmtrs)
		{
			try
			{
                //string ps = "Data Source=172.16.5.117; Initial Catalog=Serape; Persist Security Info = True;   User ID=sa;   Password=*SHyFP*Ch14p45*;";
                var connectionString = "Data Source=172.16.0.15; Initial Catalog=SICAD_BD; Persist Security Info = True;   User ID=sa;   Password=*contralo%1;";
				//connectionString = "Server=WIN-MVQQD74KM80;Database=SICAD_BD;User Id=sa;Password=contralo%1;";
				//using (var cnn = new SqlConnection(cnnStr))
				using (var cnn = new SqlConnection(connectionString))
				{
					var r = await cnn.QueryAsync<T>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
					var d = r;
					return await Task.FromResult(d);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		/***************/
		public async Task<IEnumerable<T>> GetQryCllctnDataAync(string byQuery, object prmtrs)
        {
            try
            {
                using (var cnn = new SqlConnection(cnnStr))
                {
                    //byQuery = "SELECT TOP (1000) * FROM [SICAD_BD_PRUEBA].[dbo].[tblUsuarios]"; // Test 15
                    var r = await cnn.QueryAsync<T>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
                    var d = r;
                    return await Task.FromResult(d);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> GetQrySnglDataFRSTAync(string byQuery, object prmtrs)
        {
            try
            {
                using (var cnn = new SqlConnection(cnnStr))
                {
                    //var id = await cnn.QueryAsync<int>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
                    var id = await cnn.QuerySingleAsync<int>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
                    return await Task.FromResult(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> GetQrySnglDataAync(string byQuery, object prmtrs)
        {
            try
            {
                using (var cnn = new SqlConnection(cnnStr))
                {
                    var r = await cnn.QuerySingleOrDefaultAsync<T>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
                    var d = r;
                    return await Task.FromResult(d);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		public async Task<bool> SetInsertDataAsync(string byQuery, object prmtrs)
		{
			try
			{
				using (var cnn = new SqlConnection(cnnStr))
				{
					var r = await cnn.QuerySingleOrDefaultAsync<T>(byQuery, prmtrs, commandType: System.Data.CommandType.Text);
					var d = r;
					return await Task.FromResult(true);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public Task<IEnumerable<T>> GetSPCllctnDataAync(string byStrPrcdr, object prmtrs)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetSPSnglDataAync(string byQuery, object prmtrs)
        {
            throw new NotImplementedException();
        }
        public Task<bool> SetUpdateDataAsync(string byQuery, object prmtrs)
        {
            throw new NotImplementedException();
        }
    }
}
