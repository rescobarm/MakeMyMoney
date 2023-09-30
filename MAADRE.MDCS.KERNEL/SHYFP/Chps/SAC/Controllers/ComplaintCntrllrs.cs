using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Controllers
{
    public class ComplaintCntrllrs : IComplaintService
    {
        private readonly ICmplntSrvc _ics;
        private readonly ICmplntWSSrvc _icwss;
        public ComplaintCntrllrs(ICmplntWSSrvc icwss)
        {// ok
            _icwss = icwss;
        }

        public ComplaintCntrllrs(ICmplntSrvc ics, ICmplntWSSrvc icwss)
        {
            _ics = ics;
            _icwss = icwss;
        }

        public async Task<IEnumerable<CCmbBxOptns>> GetGovAgencyWS()
        {
            try
            {
                var rspn = await _icwss.GetGobAgency("dpndncs");
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<CCmbBxOptns>> GetGovAgency()
        {
            try
            {
                var rspn = _ics.GetGovAgency();
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CCmbBxOptns>> GetCatalogs(string opt, string ce)
		{
			var rspn = await _ics.GetCatalogs(opt, ce);
			return rspn;
		}

		public Task<string> GetTest()
        {
            try
            {
                var resp = _ics.GetTest();
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        
        #region CRUD COMPLAINT
        public async Task<IEnumerable<COmplaint>> GetRecordsAsync(string opt)
        {
            try
            {
                var rsp = await _ics.GetRecordsAsync(opt);
                return rsp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<COmplaint> PostComplaint(COmplaint obj)
        {
            var rspn = await _ics.SaveRecordByAdmin(obj);
            return rspn;
        }

        public async Task<COmplaint> SaveRecordByAdmin(COmplaint obj)
        {
            var rspn = await _ics.SaveRecordByAdmin(obj);
            return rspn;
        }
        public async Task<bool> UpdateRecordByAdmin(COmplaint obj)
        {
            var rspn = await _ics.UpdateRecordByAdmin(obj);
            return rspn;
        }
		#endregion
		
		
        public Task<IEnumerable<CCmbBxOptns>> GetEntities()
		{
            try
            {
                var rspn = _ics.GetEntities();
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
		}
        
        public Task<IEnumerable<CCmbBxOptns>> GetPositions()
        {
            try
            {
                var rspn = _ics.GetPositions();
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Task<COmplaint> GetRecordBy(int idRecord)
        {
            try
            {
                var rspn = _ics.GetRecordBy(idRecord);
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetScholarship()
        {
            try
            {
                var rspn = await _ics.GetEducation();
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetOcupation()
        {
            try
            {
                var rspn = await _ics.GetCatalogs("ocptn", null);
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetAdministrativeOffenses()
        {
            try
            {
                var rspn = await _ics.GetCatalogs("admoff", null);
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetEducationLevel()
        {
            try
            {
                var rspn = await _ics.GetCatalogs("sclrdd", null);
                return rspn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Task<IEnumerable<CCmbBxOptns>> GetFederalPublicProgram()
		{
			throw new NotImplementedException();
		}
	
		public Task<bool> SetTracingByAdmin(COmplaint obj, CTracing otr)
		{
			throw new NotImplementedException();
		}
		public Task<string> UploadProductImage(MultipartFormDataContent content)
		{
			throw new NotImplementedException();
		}
    }
}
