using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class VMenu
    {
        public int Id { get; set; }
        public int IdParent { get; set; }
        public bool IsParent { get; set; }
        public string MenuName { get; set; }
        public string RoleName { get; set; }
        public string Src { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
    }

    public class VMenuCollection : ObservableCollection<VMenu>
    {
        public VMenuCollection() : base() { }
        public VMenuCollection(IEnumerable<VMenu> OIE) : base(OIE) { }
    }
}
