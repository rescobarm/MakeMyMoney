using System.Text.Json.Serialization;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CRating
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("idExam")]
        public int IdExam { get; set; }
        [JsonPropertyName("idTrainee")]
        public int IdTrainee { get; set; }
        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }
        [JsonPropertyName("opportunity")]
        public string Opportunity { get; set; }
        [JsonPropertyName("isItActive")]
        public bool IsItActive { get; set; }
        [JsonPropertyName("examName")]
        public string ExamName { get; set; }
        [JsonPropertyName("examDscrptn")]
        public string ExamDscrptn { get; set; }
        [JsonPropertyName("examApplctnDt")]
        public DateTime ExamApplctnDt { get; set; }
    }
}
