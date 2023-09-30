using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Interfaces
{
    public interface IWSrvc<T>
    {
        Task<T> GetAll();
        Task<T> GetAll(string byParm);
    }
}
