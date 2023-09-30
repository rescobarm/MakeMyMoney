using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Interfaces
{
    public interface IP3AAdminCntrllr
    {
        Task<IEnumerable<CChartInfo>> GetPeriodRptInfo();
        Task<IEnumerable<CTrainee>> GetTrainees4KrdxBy(int diPeriod);
        Task<byte[]> GetRptFile(int id);

        Task<IEnumerable<CPTP4ACSPeriods>> GetAllCPTP4ACSPeriodsAsync();
        Task<IEnumerable<CPrdsTrnngSbjcts>> GetPrdsTrnngSbjctsById(int idPrd);
        Task<CPTP4ACSPeriods> SetCPTP4ACSPeriodsAsync(CPTP4ACSPeriods oPeriod);
        Task<IList<CSubject>> GetAllSubjectsAsync();
        Task<IList<CTrainersAvailable>> GetTrainersAvailablesByAsync(int idSubject);
        Task<CPrdsTrnngSbjcts> SetPrdsTrnngSbjctsBy(CPrdsTrnngSbjcts oPTS);
        Task<IList<CTrainee>> GetTraineesAsync(int idPTS);
        Task<CTrainee> SetTraineesByAsync(CTrainee oT);
        Task<IEnumerable<UserCARD>> GetUserCARDsByAsync(string fullName);
        Task<IEnumerable<CExam>> GetExamsByAsync(int idPrd, int idSbjct);
        Task<IEnumerable<CRating>> GetRatingsBy(int idE, int idT);
        Task<CRating> SetQualification(CRating oR);
        Task<IEnumerable<CExam>> GetExamsByAsync(int idPrdsTrnrSbjct);
        Task<CExam> SetExamAsync(CExam oE);
        Task<CSubject> UpdateSubject(CSubject oSbjct);
        Task<CSubject> SetSubject(CSubject oSbjct);
        Task<CTrainersAvailable> SetTrainersAvailablesByAsync(CTrainersAvailable oTA);
    }
}
