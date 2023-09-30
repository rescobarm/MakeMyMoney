using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Interfaces
{
    public interface IREDISGnrcCRUD<T>
    {
        Task<string> GetListSerializeAsync(string k);
        Task SetTEAsync(string key, string srlzObj);
        Task SetWTEAsync(string key, string value, DateTime expr);
        Task DeleteAsync(string key);
        Task<IQueryable<T>> GetQrybl(string k);
        Task<bool> CheckKey(string k);
        Task<string> GetStringValueAsync(string k);
    }
}
