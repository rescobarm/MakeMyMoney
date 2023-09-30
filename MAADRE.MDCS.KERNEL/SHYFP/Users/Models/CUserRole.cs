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
    [Table("DUserRoles")]
    public class CUserRole : IdentityUserRole<string>
    {
        public string Observation { get; set; }
    }

    public class UserRoleCollection : ObservableCollection<CUserRole>
    {
        public UserRoleCollection() : base() { }
        public UserRoleCollection(IEnumerable<CUserRole> OIE) : base(OIE) { }
    }
}
