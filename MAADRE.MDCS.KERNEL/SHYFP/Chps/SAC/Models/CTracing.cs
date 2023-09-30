using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models
{
    public class CTracing
    {
        public int Id { get; set; }
        public int IdRecord { get; set; }
        public int TurnedTo { get; set; }
        public int IdLawyer { get; set; }
        public string Observation { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
