using System.ComponentModel.DataAnnotations;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models
{
    public class CSubject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la materia es requerido")]
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
