using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Models
{
    public class CTicker
    {
        public bool success { get; set; }
        public Payload payload { get; set; }
    }

    public class Payload
    {
        public string high { get; set; }
        public string last { get; set; }
        public DateTime created_at { get; set; }
        public string book { get; set; }
        public string volume { get; set; }
        public string vwap { get; set; }
        public string low { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string change_24 { get; set; }
        public Rolling_Average_Change rolling_average_change { get; set; }
    }

    public class Rolling_Average_Change
    {
        public string _6 { get; set; }
    }
}
