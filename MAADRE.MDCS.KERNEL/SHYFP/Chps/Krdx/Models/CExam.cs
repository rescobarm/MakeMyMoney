using System.ComponentModel.DataAnnotations;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CExam
    {
        public int Id { get; set; }
        public int IdPrdsTrnrSbjct { get; set; }
        [Required(ErrorMessage = "El nombre del examen es requerido")]
        public string ExamName { get; set; }
        [Required(ErrorMessage = "Descripción del examen es requerido")]
        public string ExamDscrptn { get; set; }
        public DateTime ExamApplctnDt { get; set; }
    }
}
