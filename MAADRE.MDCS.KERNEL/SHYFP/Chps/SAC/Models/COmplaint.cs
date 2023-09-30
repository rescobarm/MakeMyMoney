using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models
{
    public class COmplaint
    {
        public int id { get; set; }
        public string folio_system { get; set; }
        public string folio { get; set; }
        public string folio_turno { get; set; }
        public string expediente { get; set; }
        public int id_falta { get; set; }
        public int id_status { get; set; }
        public int? IdTurnedTo { get; set; }
        public int? IdLawyer { get; set; }
        public string demandante { get; set; }
        public DateTime fecha_denuncia { get; set; }
        public string hora_denuncia { get; set; }
        public string lugar_denuncia { get; set; }
        public string institucion { get; set; }
        public string tramite { get; set; }
        public string narracion { get; set; }
        public int id_programa { get; set; }
        public string persona_demandada { get; set; }
        public string testigo { get; set; }
        public string dcmnts_spprtng_claim { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public bool esAnonimo { get; set; }
        public int particular_servidor { get; set; }
        public bool requiereMedida { get; set; }
        public int id_dependencia { get; set; }
        public string curp { get; set; }
        public int id_falta_administrativa { get; set; }
        [MaxLength(100)]
        public string nombreDemandante { get; set; }
        [MaxLength(100)]
        public string paternoDemandante { get; set; }
        [MaxLength(100)]
        public string maternoDemandante { get; set; }
        public int sexoDemandante { get; set; }
        [MaxLength(100)]
        public string edadDemandante { get; set; }
        public int id_escolaridad { get; set; }
        public int id_ocupacion { get; set; }
        public int id_municipality_wtetp { get; set; }
        public int id_government_agency { get; set; }
        public string representa_a { get; set; }
        [MaxLength(30)]
        public string codigo { get; set; }
        public int IdConductCatalog { get; set; }
        public int IdReceivingMedium { get; set; }
        public bool revisado { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
