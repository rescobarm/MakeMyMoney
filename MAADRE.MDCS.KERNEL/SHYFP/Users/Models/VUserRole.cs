using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class VUserRole
    {
        public string Id { get; set; }
        public string IdRole { get; set; }
        public string EMail { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }

    public class VUserRoleCollection : ObservableCollection<VUserRole>
    {
        public VUserRoleCollection() : base() { }
        public VUserRoleCollection(IEnumerable<VUserRole> OIE) : base(OIE) { }
    }
}
