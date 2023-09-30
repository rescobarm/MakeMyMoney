using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class Employee
    {
        public int IdWorker { get; set; }
        public int IdOption { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
    public class UserCARD
    {
        public int Id { get; set; }
        //public string JWToken { get; set; }
        public int IdDpartament { get; set; }
        public int IdCategory { get; set; }
        public string LName { get; set; }
        public string MLName { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string JobOrder { get; set; }
        public string Ascription { get; set; }
        public string LaborDepartament { get; set; }
        public byte[] Picture { get; set; }
        public bool IsActive { get; set; }
    }

    public class Trabajador
    {
        public int idTrabajador { get; set; }
        public int idDepartamento { get; set; }
        public int idCategoria { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string huella { get; set; }
        public bool eliminado { get; set; }
        public int idRol { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public int idDireccion { get; set; }
        public byte[] Foto { get; set; }
        public bool checa { get; set; }
        public int idTipoHorario { get; set; }
        public bool Autorizado { get; set; }
        public string grupo { get; set; }
    }
}