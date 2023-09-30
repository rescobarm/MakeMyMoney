using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CTrainersAvailable
    {
        public int Id { get; set; }
        public int IdSubject { get; set; }
        public int IdTrainer { get; set; }
        public bool IsItAvailabe { get; set; }
        public int Priority { get; set; }
        public UserCARD? userCARD { get; set; }
    }
}
