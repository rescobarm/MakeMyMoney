using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Interfaces
{
    public interface IREDISUserCARDSrvc
    {
        Task<IQueryable<UserCARD>> GetAllCARDsAsync();
    }
}
