using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    [Table("DRoleMenu")]
    public class CRoleMenu
    {
        public int Id { get; set; }
        public virtual string CRoleId { get; set; }
        public virtual int CMenuId { get; set; }
    }

    public class RoleMenuCollection : ObservableCollection<CRoleMenu>
    {
        public RoleMenuCollection() : base() { }
        public RoleMenuCollection(IEnumerable<CRoleMenu> OIE) : base(OIE) { }
    }
}