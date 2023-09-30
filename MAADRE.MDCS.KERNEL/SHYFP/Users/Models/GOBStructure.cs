using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class COrganisms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual UserOrganismCollection DUserOrganismId { get; set; }

    }

    public class OrganismsCollection : ObservableCollection<COrganisms>
    {
        public OrganismsCollection() : base() { }
        public OrganismsCollection(IEnumerable<COrganisms> OIE) : base(OIE) { }
    }

    /************************/
    public class DUserOrganism
    {
        public int Id { get; set; }
        public bool IsAttached { get; set; }
        public virtual int COrganismsId { get; set; }
        public virtual UserRoleCollection CUserRoleId { get; set; }
    }

    public class UserOrganismCollection : ObservableCollection<DUserOrganism>
    {
        public UserOrganismCollection() : base() { }
        public UserOrganismCollection(IEnumerable<DUserOrganism> OIE) : base() { }
    }

    /************************/

    public class CClassifications
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual OrganismsCollection COrganismsId { get; set; }
    }

    public class ClassificationsCollection : ObservableCollection<CClassifications>
    {
        public ClassificationsCollection() : base() { }
        public ClassificationsCollection(IEnumerable<CClassifications> OIE) : base(OIE) { }
    }
}
