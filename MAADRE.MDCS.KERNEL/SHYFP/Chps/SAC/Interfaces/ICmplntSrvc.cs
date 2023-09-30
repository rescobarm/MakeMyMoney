using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Interfaces
{
    public interface ICmplntSrvc
    {
        Task<IEnumerable<CCmbBxOptns>> GetCatalogs(string opt, string ce);
        Task<IEnumerable<CCmbBxOptns>> GetEntities();
        Task<IEnumerable<CCmbBxOptns>> GetMunicipalities();
        Task<IEnumerable<CCmbBxOptns>> GetLocalities(string ce);

        Task<IEnumerable<CCmbBxOptns>> GetGovAgency();
        Task<IEnumerable<CCmbBxOptns>> GetFederalPublicProgram();
        Task<IEnumerable<CCmbBxOptns>> GetEducation();
        //Task<IEnumerable<CCmbBxOptns>> GetOcupation();
        Task<IEnumerable<CCmbBxOptns>> GetAdministrativeOffenses();
        Task<IEnumerable<CCmbBxOptns>> GetPositions();
        

        //Task<COmplaint> PostComplaint(COmplaint obj);
        Task<string> PostComplaint(COmplaint obj);
        Task<string> UploadProductImage(MultipartFormDataContent content);
        Task<IEnumerable<COmplaint>> GetRecordsAsync(string opt);
        //Task<bool> SaveRecordByAdmin(COmplaint obj);
        Task<COmplaint> SaveRecordByAdmin(COmplaint cmplnt);
        Task<bool> SetTracingByAdmin(COmplaint obj, CTracing otr);
        Task<COmplaint> GetRecordBy(int idRecord);
        Task<bool> UpdateRecordByAdmin(COmplaint obj);
        Task<string> GetTest();
    }
}
