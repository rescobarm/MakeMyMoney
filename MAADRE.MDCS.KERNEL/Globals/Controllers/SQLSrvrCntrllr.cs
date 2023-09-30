using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.Globals.Services;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Controllers
{
    public class SQLSrvrCntrllr : ISQLSrvrCntrllr
    {
        private readonly SQLSrvrSrvc _gcbc;
        public SQLSrvrCntrllr(SQLSrvrSrvc gcbc)
        {
            _gcbc = gcbc;
        }
        public Task GetTest()
        {
            var some = _gcbc.GetTest();
            return some;
        }
    }
}
