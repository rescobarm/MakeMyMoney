using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    [Table("CMenus")]
    public class CMenu
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public bool IsParent { get; set; }
        public string MenuName { get; set; }
        public string Src { get; set; }
        public bool Status { get; set; }
        public DateTime DCreation { get; set; }

        public virtual string CUserId { get; set; }
        public UserMenuCollection DUserMenuId { get; set; }
        public RoleMenuCollection DRoleMenuId { get; set; }
    }

    public class MenuCollection : ObservableCollection<CMenu>
    {
        public MenuCollection() : base() { }
        public MenuCollection(IEnumerable<CMenu> OIE) : base(OIE) { }
        public MenuCollection(IQueryable<CMenu> OIE) : base(OIE) { }
    }
}