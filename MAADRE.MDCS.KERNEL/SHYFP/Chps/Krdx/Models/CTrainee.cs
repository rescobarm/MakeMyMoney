

using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CTrainee
    {
        public int Id { get; set; }
        public int IdPrdsTrnrSbjct { get; set; }
        public int IdWorker { get; set; }
        public UserCARD OUserCARD { get; set; }
    }
}
