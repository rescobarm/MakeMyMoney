using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Services
{
    public class SQLSrvrSrvc : ISQLSrvrCntrllr
    {
        private readonly IDbDMGnrcCRUD<CCmbBxOptns> _gcbc;

        public SQLSrvrSrvc(IDbDMGnrcCRUD<CCmbBxOptns> gcbc)
        {
            _gcbc = gcbc;
        }

        public async Task GetTest()
        {
            try
            {
                var some = await _gcbc.GetQryCllctnDataAync("SELECT TOP (10) idFalta, idTrabajador, idIncidencia, idAsistencia, fecha, observacion, eliminado FROM tblFaltas", new { });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
