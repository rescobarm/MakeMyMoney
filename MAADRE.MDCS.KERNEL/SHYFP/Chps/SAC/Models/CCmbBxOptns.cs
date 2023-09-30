using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models
{
    public class CCtlgOptns
    {
		public string opt { get; set; }
		public string ce { get; set; }

	}
    public class CCmbBxOptns
    {
        public int id { get; set; }
        public int idParent { get; set; }
        public string value { get; set; }
        public bool isActive { get; set; }
	}
}
