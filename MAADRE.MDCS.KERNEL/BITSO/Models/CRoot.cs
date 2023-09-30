using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.BITSO.Models
{
    /****************************************/
    public class TradeBuy
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("book")]
        public string Book { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("major")]
        public double Major { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        public string? Status { get; set; }
    }
    public class TradeSell
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("book")]
        public string Book { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; }
        [JsonProperty("major")]
        public double Major { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        public string? Status { get; set; }
    }
    /************************************************/

    public class PostPayloadOrderOID
    {
        public string oid { get; set; }
    }

    public class RootPostOrderBack
    {
        public bool success { get; set; }
        public PostPayloadOrderOID payload { get; set; }
    }


    /****************************************/

    public class RollingAverageChange
	{
		[JsonProperty("6")]
		public string _6 { get; set; }
	}

	public class CRoot
	{
		public bool success { get; set; }
		public List<PayloadUserTradesRoot> payload { get; set; }
	}

	public class CTiker
	{
		public bool success { get; set; }
		public PayloadUserTradesRoot payload { get; set; }
	}
	/****************/
	public class PayloadUserTradesRoot
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
		public RollingAverageChange rolling_average_change { get; set; }
	}




}
