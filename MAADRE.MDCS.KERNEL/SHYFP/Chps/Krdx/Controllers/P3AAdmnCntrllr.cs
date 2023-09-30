using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Controllers
{
    public class P3AAdmnCntrllr : IP3AAdminCntrllr
    {
        private readonly IP3AAdminSrvc _P3AAdminSrvc;
        public P3AAdmnCntrllr(IP3AAdminSrvc p3AAdminSrvc)
        {
            _P3AAdminSrvc = p3AAdminSrvc;
        }
        #region Index
        public async Task<IEnumerable<CChartInfo>> GetPeriodRptInfo()
        {
            try
            {
                var r = await _P3AAdminSrvc.GetPeriodRptInfo();
                return r;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<byte[]> GetRptFile(int id)
        {
            try
            {
                var r = await _P3AAdminSrvc.GetRptFile(id);
                return r;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<CTrainee>> GetTrainees4KrdxBy(int idPeriod)
        {
            var r = await _P3AAdminSrvc.GetTrainees4KrdxBy(idPeriod);
            return r;
        }
        #endregion Index

        #region Administrative
        public async Task<IEnumerable<CPTP4ACSPeriods>> GetAllCPTP4ACSPeriodsAsync()
        {
            try
            {
                return await _P3AAdminSrvc.GetAllCPTP4ACSPeriodsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CPrdsTrnngSbjcts>> GetPrdsTrnngSbjctsById(int idPrd)
        {
            try
            {
                return await _P3AAdminSrvc.GetPrdsTrnngSbjctsById(idPrd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CPTP4ACSPeriods> SetCPTP4ACSPeriodsAsync(CPTP4ACSPeriods oPeriod)
        {
            return await _P3AAdminSrvc.SetCPTP4ACSPeriodsAsync(oPeriod);
        }

        public async Task<IList<CSubject>> GetAllSubjectsAsync()
        {
            return await _P3AAdminSrvc.GetAllSubjectsAsync();
        }

        public async Task<IList<CTrainersAvailable>> GetTrainersAvailablesByAsync(int idSubject)
        {
            return await _P3AAdminSrvc.GetTrainersAvailablesByAsync(idSubject);
        }

        public async Task<CPrdsTrnngSbjcts> SetPrdsTrnngSbjctsBy(CPrdsTrnngSbjcts oPTS)
        {
            return await _P3AAdminSrvc.SetPrdsTrnngSbjctsBy(oPTS);
        }

        public async Task<IList<CTrainee>> GetTraineesAsync(int idPTS)
        {
            var oc = await _P3AAdminSrvc.GetTraineesAsync(idPTS);
            return oc.ToList();
        }

        public async Task<CTrainee> SetTraineesByAsync(CTrainee oT)
        {
            return await _P3AAdminSrvc.SetTraineesByAsync(oT);
        }

        public async Task<IEnumerable<UserCARD>> GetUserCARDsByAsync(string fullName)
        {
            return await _P3AAdminSrvc.GetUserCARDsByAsync(fullName);
        }

        public async Task<IEnumerable<CExam>> GetExamsByAsync(int idPrd, int idSbjct)
        {
            return await _P3AAdminSrvc.GetExamsByAsync(idPrd, idSbjct);
        }

        public async Task<IEnumerable<CRating>> GetRatingsBy(int idE, int idT)
        {
            return await _P3AAdminSrvc.GetRatingsBy(idE, idT);
        }

        public async Task<CRating> SetQualification(CRating oR)
        {
            return await _P3AAdminSrvc.SetQualification(oR);
        }

        public async Task<IEnumerable<CExam>> GetExamsByAsync(int idPrdsTrnrSbjct)
        {
            return await _P3AAdminSrvc.GetExamsByAsync(idPrdsTrnrSbjct);
        }

        public async Task<CExam> SetExamAsync(CExam oE)
        {
            return await _P3AAdminSrvc.SetExamAsync(oE);
        }

        public async Task<CSubject> UpdateSubject(CSubject oSbjct)
        {
            return await _P3AAdminSrvc.UpdateSubject(oSbjct);
        }

        public async Task<CSubject> SetSubject(CSubject oSbjct)
        {
            return await _P3AAdminSrvc.SetSubject(oSbjct);
        }

        public async Task<CTrainersAvailable> SetTrainersAvailablesByAsync(CTrainersAvailable oTA)
        {
            return await _P3AAdminSrvc.SetTrainersAvailablesByAsync(oTA);
        }
        #endregion Administrative



    }
}