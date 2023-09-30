using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Models
{
    public class ListOrderTrades
    {
        public bool success { get; set; }
        public List<Payload> payload { get; set; }

        public class Payload
        {
            public string fees_amount { get; set; }
            public string side { get; set; }
            public string minor { get; set; }
            public string major_currency { get; set; }
            public string book { get; set; }
            public DateTime created_at { get; set; }
            public string minor_currency { get; set; }
            public string oid { get; set; }
            public string maker_side { get; set; }
            public string tid { get; set; }
            public string major { get; set; }
            public string price { get; set; }
            public string fees_currency { get; set; }
        }
    }
}
