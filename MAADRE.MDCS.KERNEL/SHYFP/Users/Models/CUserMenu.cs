using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    [Table("DUserMenu")]
    public class CUserMenu
    {
        public int Id { get; set; }
    }

    public class UserMenuCollection : ObservableCollection<CUserMenu>
    {
        public UserMenuCollection() : base() { }
        public UserMenuCollection(IEnumerable<CUserMenu> OIE) : base(OIE) { }
    }
}