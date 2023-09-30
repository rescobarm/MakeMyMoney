using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Services
{
    public class REDISSrvc : IREDISUserCARDSrvc
    {
        private readonly IREDISGnrcCRUD<UserCARD> _irsgc;
        private readonly IDbDMGnrcCRUD<UserCARD> _icbo;
        public REDISSrvc(IREDISGnrcCRUD<UserCARD> irsgc, IDbDMGnrcCRUD<UserCARD> icbo)
        {
            _irsgc = irsgc;
            _icbo = icbo;
        }
        public async Task<IQueryable<UserCARD>> GetAllCARDsAsync()
        {
            try
            {
                var b = await _irsgc.CheckKey("users");
                if (!b)
                    b = await GetUserCARDs();
                if (!b)
                    throw new Exception("No se ha podido cargar datos en cache");

                var oq = await _irsgc.GetQrybl("users");
                //var oqr = oq.Where(x => x.IdDpartament == 218);
                //var oqr = oq;
                return oq;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> GetUserCARDs()
        {
            string k = "users";
            try
            {
                var q = @"SELECT dbo.tblTrabajador.idTrabajador AS Id, dbo.tblTrabajador.idDepartamento AS IdDpartament, dbo.tblTrabajador.idCategoria AS IdCategory, dbo.tblTrabajador.apPaterno AS LName, dbo.tblTrabajador.apMaterno AS MLName, 
                                dbo.tblTrabajador.nombre AS Name, LTRIM(RTRIM(dbo.tblTrabajador.apPaterno)) + ' ' + LTRIM(RTRIM(dbo.tblTrabajador.apMaterno)) + ' ' + LTRIM(RTRIM(dbo.tblTrabajador.nombre)) AS FullName, dbo.tblTrabajador.Autorizado, 
                                dbo.tblTrabajador.checa, dbo.tblTrabajador.Foto AS picture, dbo.tblTrabajador.idTipoHorario, dbo.catDepartamento.departamento AS laborDepartament, dbo.catDepartamento.eliminado AS IsDepartmentDown, 
                                dbo.catDepartamento.idDireccion As IdDrcctn, dbo.catDirecciones.direccion AS Ascription, dbo.catDirecciones.eliminado AS IsDirectionDown, dbo.tblTrabajador.eliminado AS IsWorkerDown, dbo.catCategoria.categoria AS jobOrder, 
                                dbo.catCategoria.eliminado AS IsJobOrderDown
                                FROM dbo.tblTrabajador INNER JOIN
                                dbo.catDepartamento ON dbo.tblTrabajador.idDepartamento = dbo.catDepartamento.idDepartamento INNER JOIN
                                dbo.catDirecciones ON dbo.catDepartamento.idDireccion = dbo.catDirecciones.id INNER JOIN
                                dbo.catCategoria ON dbo.tblTrabajador.idCategoria = dbo.catCategoria.idCategoria 
                                WHERE dbo.tblTrabajador.eliminado = 0";
                //var dsc = await _icbo.GetQryCllctnDataAync(q, new { });
                var dsc = await _icbo.GetQryCllctnDataAync_sicdb(q, new { });
                if (dsc != null)
                    await _irsgc.SetTEAsync(k, JsonSerializer.Serialize(dsc));
                else
                    throw new Exception("SQL Problem");
                return true;
                //await _irs.DeleteAsync(k);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
