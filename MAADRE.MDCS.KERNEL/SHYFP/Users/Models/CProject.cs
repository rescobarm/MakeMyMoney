using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public interface IProjectSrvc
    {
        Task<ProjectCollection> GetProjectAllAsync();
        Task<ProjectCollection> GetProjectAllAsync(string byIdUser);
        Task<bool> SetProgect(CProject oPrj);
    }

    public class CProject
    {
        public int Id { get; set; }
        /// <summary>
        /// Id SQLite
        /// </summary>        
        public int IdProject { get; set; }
        public virtual string CUserId { get; set; }
        public int CProjectCatId { get; set; }
        public string ProjectName { get; set; }
        public DateTime DTCreation { get; set; }
        public bool ActiveProject { get; set; }
        public DateTime DateUpdate { get; set; }
    }

    public class ProjectCollection : ObservableCollection<CProject>
    {
        public ProjectCollection() : base() { }
        public ProjectCollection(IEnumerable<CProject> OIC) : base(OIC) { }
    }
}
