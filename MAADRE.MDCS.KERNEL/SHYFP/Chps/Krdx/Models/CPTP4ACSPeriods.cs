using System.ComponentModel.DataAnnotations;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CPTP4ACSPeriods
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del periodo")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese la fecha de inicio del periodo")]
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
