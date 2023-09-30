using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Interfaces
{
    public interface IUserSrvc
    {
        Task<Trabajador> GetUserInfo(string cardData);
        Task<string> GetAuth(CUsrInf oU);
        Task<bool> GetLogOut();
        Task<bool> OnSendValidmail(CUsrInf oUsrInf);
        Task<IEnumerable<COmplaint>> GetComplaintsBy(CUsrInf oUI);
        Task SendMessage(ChatMessage message);
    }
}
