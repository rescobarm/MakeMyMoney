using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models
{
	public class CPlaintiffs
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno es requerido")]
        public string APaterno { get; set; }

        [Required(ErrorMessage = "El apellido materno es requerido")]
        public string AMaterno { get; set; }

        [Required(ErrorMessage = "El sexo es requerido")]
        public int IdSexo { get; set; } = 0;

        [Required(ErrorMessage = "El RFC es requerido")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "El rango de edad es requerido")]
        public int IdAgeRange { get; set; } = 0;

        [Required(ErrorMessage = "La clave de elector es requerida")]
        public string ElectorKey { get; set; }
        [Required(ErrorMessage = "El tipo de persona es requerido")]
		public int IdPersonType { get; set; } //Física, moral, etc...

		public bool IsItIndigenous { get; set; } = false;

		public int IdJobAssignment { get; set; }
		
		public int IdCountry { get; set; }
		public int IdState { get; set; }

		public int IdMunicipality { get; set; }
		public int IdLocality { get; set; }

		[Required(ErrorMessage = "El código postal es requerido")]
		public string CP { get; set; }
		[Required(ErrorMessage = "La dirección es requerida")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Un número de teléfono es requerido")]
		public string NoPhone { get; set; }
		public string Ocupation { get; set; }
		[Required(ErrorMessage = "Un correo es requerido")]
		public string EMail { get; set; }
		public bool IsActive { get; set; }
	}

	public class CDefendant
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "El encargo es requerido")]
		public int IdJobAssignment { get; set; }
		[Required(ErrorMessage = "Nombre del demandado requerido")]
		public string Defendant { get; set; }
		public bool IsActive { get; set; }
	}
}
