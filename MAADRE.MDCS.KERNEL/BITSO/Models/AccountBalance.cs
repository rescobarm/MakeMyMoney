using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Models
{
    public class AccountBalancePL
    {
        public bool success { get; set; }
        public AccountBalancePayload payload { get; set; }

    }
    public class AccountBalancePayload
    {
        public AccountBalance[] balances { get; set; }
    }
    public class AccountBalance
	{
		public bool success { get; set; }
		public Payload payload { get; set; }
		

		public class Payload
		{
			public Balance[] balances { get; set; }
		}

		public class Balance
		{
			public string currency { get; set; }
			public string available { get; set; }
			public string locked { get; set; }
			public string total { get; set; }
			public string pending_deposit { get; set; }
			public string pending_withdrawal { get; set; }
		}

		//public class Payload
		//{
		//	public string high { get; set; }
		//	public string last { get; set; }
		//	public DateTime created_at { get; set; }
		//	public string book { get; set; }
		//	public string volume { get; set; }
		//	public string vwap { get; set; }
		//	public string low { get; set; }
		//	public string ask { get; set; }
		//	public string bid { get; set; }
		//	public string change_24 { get; set; }
		//	public RollingAverageChange rolling_average_change { get; set; }
		//}
	}
}
