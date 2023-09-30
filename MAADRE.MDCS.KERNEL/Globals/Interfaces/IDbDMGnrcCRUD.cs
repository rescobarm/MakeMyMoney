using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Interfaces
{
    public interface IDbDMGnrcCRUD<T>
    {
        Task<T> GetQrySnglDataAync(string byQuery, object prmtrs);
        Task<IEnumerable<T>> GetQryCllctnDataAync(string byQuery, object prmtrs);
        Task<IEnumerable<T>> GetQryCllctnDataAync_sicdb(string byQuery, object prmtrs);

        Task<T> GetSPSnglDataAync(string byQuery, object prmtrs);
        Task<IEnumerable<T>> GetSPCllctnDataAync(string byStrPrcdr, object prmtrs);

        Task<int> GetQrySnglDataFRSTAync(string byQuery, object prmtrs);
        Task<bool> SetInsertDataAsync(string byQuery, object prmtrs);
        Task<bool> SetUpdateDataAsync(string byQuery, object prmtrs);
    }
}
