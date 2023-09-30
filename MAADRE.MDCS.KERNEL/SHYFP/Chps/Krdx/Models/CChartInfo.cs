using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CChartInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }

    }
}
