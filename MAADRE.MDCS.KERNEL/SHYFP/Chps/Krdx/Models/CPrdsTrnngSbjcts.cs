

using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CPrdsTrnngSbjcts
    {
        public int Id { get; set; }
        public int IdPeriod { get; set; }
        public int IdSubject { get; set; }
        public int IdTrinrAvlbl { get; set; }
        public string SbjctName { get; set; }
        public UserCARD OUserCARD { get; set; }
    }
}
