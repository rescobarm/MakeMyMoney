using MAADRE.MDCSI.KERNEL.Globals.Data;
using MAADRE.MDCSI.KERNEL.Globals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Controllers
{
    public class FrstrCntrllr
    {
        DbFrstr db;
        public FrstrCntrllr()
        {
            db = new DbFrstr("fb-maadre-db");
        }
        public async Task<IEnumerable<Item>> GetItemCollection()
        {
            var itmd = await db.GetItemCollection();
            return itmd;
        }
    }
}
