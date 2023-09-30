using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    [Table("TUsers")]
    public class CUser : IdentityUser
    {
        public int IdTrabajador { get; set; }
        public int IdDepartamento { get; set; }
        public int IdDireccion { get; set; }
        public int IdCategoria { get; set; }
        public string? IdDevice { get; set; }
        //public string? EMail { get; set; }
        [NotMapped]
        [ForeignKey("CUserId")]
        public virtual new string CUserId { get; set; }
        [NotMapped]
        public virtual UserCollection CUserId_Parent { get; set; }
        [NotMapped]
        [ForeignKey("CPersonId")]
        public virtual string CPersonId { get; set; }
        [NotMapped]
        public virtual CRoleCollection CRoleId { get; set; }
        [NotMapped]
        public virtual MenuCollection CMenuId { get; set; }
        [NotMapped]
        public virtual UserMenuCollection DUserMenuId { get; set; }
        [NotMapped]
        public virtual ProjectCollection CProjectId { get; set; }
        [NotMapped]
        public virtual UserOrganismCollection DetUserOrganismId { get; set; }
        [NotMapped]
        public int IdOrganism { get; set; }
        [NotMapped]
        public string DirectPhone { get; set; }
        [NotMapped]
        public string Profession { get; set; }
        [NotMapped]
        public int IdRol { get; set; }
        [NotMapped]
        public string PositionOrTitle { get; set; }
        [NotMapped]
        public VMenuCollection vMenus { get; set; }
    }

    public class UserCollection : ObservableCollection<CUser>
    {
        public UserCollection() : base() { }
        public UserCollection(IEnumerable<CUser> OIE) : base(OIE) { }
    }
}
