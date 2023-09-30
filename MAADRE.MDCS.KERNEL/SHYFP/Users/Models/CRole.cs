using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    [Table("CRoles")]
    public class CRole : IdentityRole
    {

        [ForeignKey("CUserId")]
        public virtual string CUserId { get; set; }
        [Required]
        [Display(Name = "RolSiglas")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Siglas del rol es muy largo.")]
        public override string Name { get; set; }
        [Required]
        [Display(Name = "RolNombre")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Nombre del rol es muy largo.")]
        public override string NormalizedName { get; set; }
        public string Description { get; set; }
        public RoleMenuCollection DRoleMenuId { get; set; }
        //public virtual UserOrganismCollection DUserOrganismId { get; set; }
    }

    public class CRoleCollection : ObservableCollection<CRole>
    {
        public CRoleCollection() : base() { }
        public CRoleCollection(IEnumerable<CRole> OIE) : base(OIE) { }
    }
}
