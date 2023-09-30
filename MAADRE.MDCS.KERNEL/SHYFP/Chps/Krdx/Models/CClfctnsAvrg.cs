using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CClfctnsAvrg
    {
        public string PeriodName { get; set; }
        public double ClfctnsAvrg { get; set; }
    }

    public class CClfctnsAvrgDtail
    {
        public int Id { get; set; }
        public string PeriodName { get; set; }
        public string SubjectName { get; set; }
        public double Rating { get; set; }
        public string Opportunity { get; set; }
        public string ExamName { get; set; }
    }
}
