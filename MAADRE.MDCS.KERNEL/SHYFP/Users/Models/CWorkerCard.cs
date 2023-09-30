using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class CWorkerCard
    {
        public int IdWCMD { get; set; }
        public int Id { get; set; }
        public int IdTrabajador { get; set; }
        public int IdDepartamento { get; set; }
        public int IdDireccion { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public string Categoria { get; set; }
        public bool Checa { get; set; }
        public int IdTipoHorario { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public int hrEntrada { get; set; }
        public int hrSalida { get; set; }
        public bool Sexo { get; set; }
        public byte[] Foto { get; set; }
    }
}
