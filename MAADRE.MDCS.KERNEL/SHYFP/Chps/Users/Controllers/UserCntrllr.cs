

using MAADRE.MDCSI.KERNEL.Globals.Data;
using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Services;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Controllers
{
    public interface IUserJWTSrvc
    {
        Task<bool> UpdateConfirmEmail(string idUser);
        Task<string> SaveWorkerCard(CUsrInf oWC);
        Task<Trabajador> GetUserInfo(string cardData);
        Task<CUsrTkn> GetUserJWTAuth(CUsrInf oUI);
    }
    public class UserCntrllr : IUserJWTSrvc
    {
        private readonly UserJWTSrvc _ius;
        private readonly IDbDMGnrcCRUD<Trabajador> _iss;
        private readonly SQLCntx _dbCntx;

        public UserCntrllr(SQLCntx dbCntx, UserJWTSrvc ius, IDbDMGnrcCRUD<Trabajador> iss)
        {
            _ius = ius;
            _iss = iss;
            _dbCntx = dbCntx;
        }
        public async Task<CUsrTkn> GetUserJWTAuth(CUsrInf oUI)
        {
            try
            {
                var ot = await _ius.GetUserJWTAuth(oUI);
                return ot;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateConfirmEmail(string idUser)
        {
            try
            {
                using (var db = _dbCntx)
                {
                    var user = db.TUser.FirstOrDefault(x => x.Id == idUser);
                    if (user == null) return await Task.FromResult(false);
                    user.EmailConfirmed = true;
                    db.TUser.Update(user);
                    await db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> SaveWorkerCard(CUsrInf oUI)
        {
            try
            {
                using (var db = _dbCntx)
                {
                    var newUser = new CUser
                    {
                        IdTrabajador = oUI.IdTrabajador,
                        IdDepartamento = oUI.IdDepartamento,
                        IdDireccion = oUI.IdDireccion,
                        IdCategoria = oUI.IdCategoria,
                        IdDevice = oUI.IdDevice,
                        Email = oUI.U
                    };
                    db.TUser.Add(newUser);
                    await db.SaveChangesAsync();

                    // El ID del registro se actualiza después de guardar cambios
                    var newUserId = newUser.Id;
                    return newUserId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Trabajador> GetUserInfo(string cardData)
        {
            try
            {
                cardData = "RUDIAR ESCOBAR MATUZ\nAUXILIAR ADMINISTRATIVO B\nUNIDAD DE INFORMÁTICA Y DESARROLLO DIGITAL";
                string[] arregloGuardado = cardData.Split('\n');
                string q = @"select * from tblTrabajador where nombre +' '+ apPaterno +' '+ apMaterno = @fullName and eliminado = 0";
                object p = new { fullName = arregloGuardado[0] };
                var t = await _iss.GetQrySnglDataAync(q, p);
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
