using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Interfaces
{
    public interface IComplaintService
    {
        Task<IEnumerable<CCmbBxOptns>> GetCatalogs(string opt, string ce);
        Task<IEnumerable<COmplaint>> GetRecordsAsync(string opt);
        Task<IEnumerable<CCmbBxOptns>> GetEntities();
		Task<string> UploadProductImage(MultipartFormDataContent content);
		Task<COmplaint> GetRecordBy(int idRecord);
		Task<IEnumerable<CCmbBxOptns>> GetGovAgency();
        Task<IEnumerable<CCmbBxOptns>> GetGovAgencyWS();
        Task<IEnumerable<CCmbBxOptns>> GetFederalPublicProgram();
		Task<IEnumerable<CCmbBxOptns>> GetEducationLevel();
		Task<IEnumerable<CCmbBxOptns>> GetOcupation();
		Task<IEnumerable<CCmbBxOptns>> GetAdministrativeOffenses();
		Task<IEnumerable<CCmbBxOptns>> GetPositions();

		Task<COmplaint> PostComplaint(COmplaint obj);
		Task<COmplaint> SaveRecordByAdmin(COmplaint obj);
        Task<bool> SetTracingByAdmin(COmplaint obj, CTracing otr);
		Task<bool> UpdateRecordByAdmin(COmplaint obj);
		Task<string> GetTest();
	}
}
