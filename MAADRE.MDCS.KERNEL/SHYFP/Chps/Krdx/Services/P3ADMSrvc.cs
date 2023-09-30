
//using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Data;
//using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Data;
using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Krdx.Services
{
    public class P3ADMSrvc : IP3AAdminSrvc
    {
        private readonly IREDISUserCARDSrvc _irucs;
        private readonly IDbDMGnrcCRUD<CChartInfo> _icids;
        private readonly IDbDMGnrcCRUD<CTrainee> _igct;
        private readonly IDbDMGnrcCRUD<CPTP4ACSPeriods> _igcp;
        private readonly IDbDMGnrcCRUD<CPrdsTrnngSbjcts> _igcpts;
        private readonly IDbDMGnrcCRUD<CSubject> _igcs;
        private readonly IDbDMGnrcCRUD<CExam> _igce;
        private readonly IDbDMGnrcCRUD<CRating> _igcr;
        private readonly IDbDMGnrcCRUD<CTrainersAvailable> _igcta;
        
        private readonly IDbDMGnrcCRUD<CDateTimePlace> _igcdtp;
        private readonly IDbDMGnrcCRUD<VCardexData> _ivcd;
        private readonly IDbDMGnrcCRUD<CClfctnsAvrg> _icfav;
        private readonly IDbDMGnrcCRUD<CClfctnsAvrgDtail> _icfavd;
        public P3ADMSrvc(IREDISUserCARDSrvc irucs, 
                         IDbDMGnrcCRUD<CChartInfo> icids, 
                         IDbDMGnrcCRUD<CTrainee> igct, 
                         IDbDMGnrcCRUD<CPTP4ACSPeriods> igcp,
                         IDbDMGnrcCRUD<CPrdsTrnngSbjcts> igcpts,
                         IDbDMGnrcCRUD<CSubject> igcs,
                         IDbDMGnrcCRUD<CExam> igce,
                         IDbDMGnrcCRUD<CRating> igcr,
                         IDbDMGnrcCRUD<CTrainersAvailable> igcta, 
                         IDbDMGnrcCRUD<CDateTimePlace> igcdtp,
                         IDbDMGnrcCRUD<VCardexData> ivcd,
                         IDbDMGnrcCRUD<CClfctnsAvrg> icfav,
                         IDbDMGnrcCRUD<CClfctnsAvrgDtail> icfavd
                    )
        {
            _irucs = irucs;
            _icids = icids;
            _igct = igct;
            _igcp = igcp;
            _igcpts = igcpts;
            _igcs = igcs;
            _igce = igce;
            _igcr = igcr;
            _igcta = igcta;
            _igcdtp = igcdtp;
            _ivcd = ivcd;
            _icfav = icfav;
            _icfavd = icfavd;
        }

        public async Task<IEnumerable<CChartInfo>> GetPeriodRptInfo()
        {
            try
            {
                string q = @"SELECT t.Id, t.Label, COUNT(t.Value) As Value FROM (	
                                SELECT dbo.tPTP4ACSPeriods.Id, dbo.tPTP4ACSPeriods.Name As Label, COUNT(dbo.tTrainees.IdWorker) As Value
                                    FROM dbo.tPTP4ACSPeriods 
                                        INNER JOIN dbo.dPrdsTrnngSbjcts ON dbo.tPTP4ACSPeriods.Id = dbo.dPrdsTrnngSbjcts.IdPeriod 
                                        INNER JOIN dbo.tTrainees ON dbo.dPrdsTrnngSbjcts.Id = dbo.tTrainees.IdPrdsTrnrSbjct
                                            Group By dbo.tPTP4ACSPeriods.Id, dbo.tPTP4ACSPeriods.Name, dbo.tTrainees.IdWorker
                                ) as t
                                    Group By t.Id, t.Label";

                var oc = await _icids.GetQryCllctnDataAync(q, null);
                return oc == null ? new List<CChartInfo>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CTrainee>> GetTrainees4KrdxBy(int diPeriod)
        {
            try
            {
                string q = @"SELECT TOP(3) dbo.tTrainees.*
                                FROM dbo.tTrainees 
                                    INNER JOIN dbo.dPrdsTrnngSbjcts ON dbo.tTrainees.IdPrdsTrnrSbjct = dbo.dPrdsTrnngSbjcts.Id
                                        WHERE (dbo.dPrdsTrnngSbjcts.IdPeriod = @IdP);";
                var oc = await _igct.GetQryCllctnDataAync(q,
                    new { IdP = diPeriod });

                if (oc != null)
                {
                    var iquc = await _irucs.GetAllCARDsAsync();
                    if (iquc != null)
                    {
                        var res = from t1 in oc.AsQueryable()
                                  join uc in iquc on t1.IdWorker equals uc.Id
                                  select new CTrainee
                                  {
                                      Id = t1.Id,
                                      IdPrdsTrnrSbjct = t1.IdPrdsTrnrSbjct,
                                      IdWorker = t1.IdWorker,
                                      OUserCARD = new UserCARD
                                      {
                                          FullName = uc.FullName,
                                          JobOrder = uc.JobOrder,
                                          Ascription = uc.Ascription,
                                          LaborDepartament = uc.LaborDepartament,
                                          Picture = uc.Picture
                                      }
                                  };
                        return res == null ? new List<CTrainee>() : ((IEnumerable<CTrainee>)(res.ToList()));
                    }
                }
                return oc == null ? new List<CTrainee>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CPTP4ACSPeriods>> GetAllCPTP4ACSPeriodsAsync()
        {
            try
            {
                string q = @"Select * From tPTP4ACSPeriods;";
                var oc = await _igcp.GetQryCllctnDataAync(q, new { });
                return oc == null ? new List<CPTP4ACSPeriods>() : oc.ToList();
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
                string q = @"Select apts.Id,
                                apts.IdPeriod,
                                apts.IdSubject,
								ts.Name as SbjctName,
                                ta.IdTrainer as IdTrinrAvlbl 
                                    From dPrdsTrnngSbjcts apts, 
										 tTrainersAvailable ta,
										 tSubjects ts
											WHERE apts.IdPeriod = @IdPeriod AND apts.IdTrinrAvlbl = ta.Id AND ts.id = apts.IdSubject;";
                var oc = await _igcpts.GetQryCllctnDataAync(q,
                    new { IdPeriod = idPrd });
                if (oc != null)
                {
                    var iquc = await _irucs.GetAllCARDsAsync();
                    if (iquc != null)
                    {
                        var res = from t1 in oc.AsQueryable()
                                  join uc in iquc on t1.IdTrinrAvlbl equals uc.Id
                                  select new CPrdsTrnngSbjcts
                                  {
                                      Id = t1.Id,
                                      IdSubject = t1.IdSubject,
                                      IdPeriod = t1.IdPeriod,
                                      IdTrinrAvlbl = t1.IdTrinrAvlbl,
                                      SbjctName = t1.SbjctName,
                                      OUserCARD = new UserCARD
                                      {
                                          FullName = uc.FullName,
                                          JobOrder = uc.JobOrder,
                                          Ascription = uc.Ascription,
                                          LaborDepartament = uc.LaborDepartament,
                                          Picture = uc.Picture
                                      }
                                  };
                        return res == null ? new List<CPrdsTrnngSbjcts>() : ((IEnumerable<CPrdsTrnngSbjcts>)(res.ToList()));
                    }
                }
                return oc == null ? new List<CPrdsTrnngSbjcts>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<byte[]> GetRptFile(int id)
        {
            throw new NotImplementedException("Funcionalidad en proceso de diseño...");
        }

        /***********************************************************/
        public async Task<IList<CSubject>> GetAllSubjectsAsync()
        {
            try
            {
                string q = @"Select * From tSubjects;";
                var oc = await _igcs.GetQryCllctnDataAync(q,
                    new { });
                return oc == null ? new List<CSubject>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<CTrainee>> GetTraineesAsync(int idPTS)
        {
            try
            {
                string q = @"Select * From tTrainees WHERE IdPrdsTrnrSbjct = @idPrdsTrnrSbjct;";
                var oc = await _igct.GetQryCllctnDataAync(q,
                    new { IdPrdsTrnrSbjct = idPTS });

                if (oc != null)
                {
                    var iquc = await _irucs.GetAllCARDsAsync();
                    if (iquc != null)
                    {
                        var res = from t1 in oc.AsQueryable()
                                  join uc in iquc.ToList() on t1.IdWorker equals uc.Id
                                  select new CTrainee
                                  {
                                      Id = t1.Id,
                                      IdPrdsTrnrSbjct = t1.IdPrdsTrnrSbjct,
                                      IdWorker = t1.IdWorker,
                                      OUserCARD = new UserCARD
                                      {
                                          FullName = uc.FullName,
                                          JobOrder = uc.JobOrder,
                                          Ascription = uc.Ascription,
                                          LaborDepartament = uc.LaborDepartament,
                                          Picture = uc.Picture
                                      }
                                  };
                        return res == null ? new List<CTrainee>() : ((IEnumerable<CTrainee>)(res.ToList()));
                    }
                }
                return oc == null ? new List<CTrainee>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<UserCARD>> GetUserCARDsByAsync(string fullName)
        {
            try
            {
                //var b = await _irsgc.CheckKey("users");
                //if (!b)
                //    b = await GetUserCARDs();
                //if (!b)
                //    throw new Exception("No se ha podido cargar datos en cache");

                //var oq = await _irsgc.GetQrybl("users");
                ////var oqr = oq.Where(x => x.IdDpartament == 218);
                var oq = await _irucs.GetAllCARDsAsync();
                var oqr = oq.ToList()
                    .Where(x => x.FullName != null && x.FullName.ToUpper()
                    .Contains(fullName.ToUpper()));

                return oqr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /***********************************************************/
        public async Task<IEnumerable<CExam>> GetExamsByAsync(int idPrd, int idSbjct)
        {
            try
            {
                string q = @"SELECT tExams.Id, tExams.ExamName, tExams.ExamDscrptn, tExams.ExamApplctnDt, 
                            dPrdsTrnngSbjcts.IdPeriod, dPrdsTrnngSbjcts.IdSubject
                                FROM dPrdsTrnngSbjcts INNER JOIN tExams ON 
                                dPrdsTrnngSbjcts.Id = tExams.IdPrdsTrnrSbjct
                            WHERE (dPrdsTrnngSbjcts.IdPeriod = @IdPrd) 
                                AND (dPrdsTrnngSbjcts.IdSubject = @IdSbjct);";

                var oc = await _igce.GetQryCllctnDataAync(q,
                    new { IdPrd = idPrd, IdSbjct = idSbjct });
                return oc == null ? new List<CExam>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CExam>> GetExamsByAsync(int idPrdsTrnrSbjct)
        {
            try
            {
                string q = @"Select * From tExams WHERE IdPrdsTrnrSbjct = @idPrdsTrnrSbjct;";
                var oc = await _igce.GetQryCllctnDataAync(q,
                    new { IdPrdsTrnrSbjct = idPrdsTrnrSbjct });
                return oc == null ? new List<CExam>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CRating>> GetRatingsBy(int idE, int idT)
        {
            try
            {
                string q = @"SELECT dbo.tRatings.Id, dbo.tRatings.IdExam, dbo.tRatings.IdTrainee, 
                                dbo.tRatings.Rating, dbo.tRatings.Opportunity, dbo.tRatings.IsItActive, 
                                dbo.tExams.ExamName, dbo.tExams.ExamDscrptn, dbo.tExams.ExamApplctnDt
                                FROM dbo.tRatings INNER JOIN dbo.tTrainees ON dbo.tRatings.IdTrainee = dbo.tTrainees.Id INNER JOIN
                                     dbo.tExams ON dbo.tRatings.IdExam = dbo.tExams.Id
	                                WHERE (dbo.tRatings.IdTrainee = @IdT and dbo.tRatings.IsItActive = 1) AND (dbo.tTrainees.IdPrdsTrnrSbjct = @IdPTS);";
                var oc = await _igcr.GetQryCllctnDataAync(q,
                    new { IdPTS = idE, IdT = idT });
                return oc == null ? new List<CRating>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CExam> SetExamAsync(CExam oE)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[tExams]([IdPrdsTrnrSbjct],
                                [ExamName], [ExamDscrptn], [ExamApplctnDt])
                                OUTPUT INSERTED.Id
                            VALUES
                                (@IdPrdsTrnrSbjct, @ExamName, @ExamDscrptn, @ExamApplctnDt)";
                int id = await _igce.GetQrySnglDataFRSTAync(q, new
                {
                    IdPrdsTrnrSbjct = oE.IdPrdsTrnrSbjct,
                    ExamName = oE.ExamName,
                    ExamDscrptn = oE.ExamDscrptn,
                    ExamApplctnDt = oE.ExamApplctnDt
                });
                oE.Id = id;
                return oE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /***********************************************************/
        public async Task<CSubject> SetSubject(CSubject oSbjct)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[tSubjects] ([Name] ,[IsActive]) 
                             OUTPUT INSERTED.Id
                             VALUES (@Name , @IsActive);";
                int id = await _igcpts.GetQrySnglDataFRSTAync(q, new { Name = oSbjct.Name, IsActive = oSbjct.IsActive });
                oSbjct.Id = id;
                return await Task.FromResult<CSubject>(oSbjct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /***********************************************************/
        public async Task<IList<CTrainersAvailable>> GetTrainersAvailablesByAsync(int idSubject)
        {
            try
            {
                string q = @"SELECT TOP (1000) [Id]
                                ,[IdSubject]
                                ,[IdTrainer]
                                ,[IsItAvailabe]
                                ,[Priority]
                                    FROM [P3A_DB].[dbo].[tTrainersAvailable]
                                        WHERE IdSubject = @idSubject";
                var oc = await _igcta.GetQryCllctnDataAync(q, new { idSubject = idSubject });
                if (oc != null)
                {
                    var kl = await _irucs.GetAllCARDsAsync();
                    if (kl != null)
                    {
                        var res = from t1 in oc.AsQueryable()
                                  join t2 in kl on t1.IdTrainer equals t2.Id
                                  select new CTrainersAvailable
                                  {
                                      Id = t1.Id,
                                      IdSubject = t1.IdSubject,
                                      IdTrainer = t1.IdTrainer,
                                      IsItAvailabe = t1.IsItAvailabe,
                                      Priority = t1.Priority,
                                      userCARD = new UserCARD
                                      {
                                          FullName = t2.FullName,
                                          JobOrder = t2.JobOrder,
                                          Ascription = t2.Ascription,
                                          LaborDepartament = t2.LaborDepartament,
                                          Picture = t2.Picture
                                      }
                                  };
                        //select new { t1.Id, t1.IdSubject, t1.IdTrainer, t1.IsItAvailabe, t1.Priority, t2.FullName, t2.JobOrder, t2.Ascription, t2.LaborDepartament, t2.Picture};
                        //IList<CTrainersAvailable> mylist = (IList<CTrainersAvailable>)res.ToList();
                        return res == null ? new List<CTrainersAvailable>() : ((IList<CTrainersAvailable>)(res.ToList()));
                    }
                    return oc == null ? new List<CTrainersAvailable>() : oc.ToList();
                }
                return null;//oc == null ? new List<CTrainersAvailable>() : oc.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CPTP4ACSPeriods> SetCPTP4ACSPeriodsAsync(CPTP4ACSPeriods oPeriod)
        {
            try
            {
                string q = string.Empty;
                if (oPeriod.Id == 0)
                {
                    q = @"INSERT INTO [dbo].[tPTP4ACSPeriods]
                                    ([Name]
                                    ,[Description]
                                    ,[InitialDate]
                                    ,[FinalDate])
                            OUTPUT INSERTED.Id
                                VALUES
                                    (@Name
                                    ,@Description
                                    ,@InitialDate
                                    ,@FinalDate)";
                    var id = await _igcp.GetQrySnglDataFRSTAync(q,
                    new
                    {
                        @Name = oPeriod.Name,
                        @Description = oPeriod.Description,
                        @InitialDate = oPeriod.InitialDate,
                        @FinalDate = oPeriod.FinalDate
                    });
                    oPeriod.Id = id;
                }
                else
                {
                    q = @"UPDATE [dbo].[tPTP4ACSPeriods] Set 
                                [Name]=@Name,
                         [Description]=@Description,
                         [InitialDate]=@InitialDate,
                           [FinalDate]=@FinalDate
                            Where [Id]=@Id";
                    var op = await _igcp.SetUpdateDataAsync(q,
                    new
                    {
                        @Name = oPeriod.Name,
                        @Description = oPeriod.Description,
                        @InitialDate = oPeriod.InitialDate,
                        @FinalDate = oPeriod.FinalDate,
                        @Id = oPeriod.Id
                    });
                }
                return oPeriod;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CPrdsTrnngSbjcts> SetPrdsTrnngSbjctsBy(CPrdsTrnngSbjcts oPTS)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[dPrdsTrnngSbjcts] ([IdPeriod],
                                       [IdSubject],
                                       [IdTrinrAvlbl])
                                OUTPUT INSERTED.Id
                                 VALUES (@IdPeriod,
                                       @IdSubject,
                                       @IdTrinrAvlbl);";
                int id = await _igcpts.GetQrySnglDataFRSTAync(q, new
                {
                    IdPeriod = oPTS.IdPeriod,
                    IdSubject = oPTS.IdSubject,
                    IdTrinrAvlbl = oPTS.IdTrinrAvlbl
                });
                oPTS.Id = id;
                return await Task.FromResult<CPrdsTrnngSbjcts>(oPTS);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CRating> SetQualification(CRating oR)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[tRatings]
                                ([IdExam], [IdTrainee], [Rating], [Opportunity], [IsItActive])
                            OUTPUT INSERTED.Id
                            VALUES (@IdExam, @IdTrainee, @Rating, @Opportunity, @IsItActive)";
                int id = await _igcr.GetQrySnglDataFRSTAync(q, new
                {
                    IdExam = oR.IdExam,
                    IdTrainee = oR.IdTrainee,
                    Rating = oR.Rating,
                    Opportunity = oR.Opportunity,
                    IsItActive = oR.IsItActive
                });
                oR.Id = id;
                return oR;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CTrainee> SetTraineesByAsync(CTrainee oT)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[tTrainees] ([IdPrdsTrnrSbjct], [IdWorker]) 
                                OUTPUT INSERTED.Id
                                    VALUES (@IdPrdsTrnrSbjct, @IdWorker)";

                int id = await _igct.GetQrySnglDataFRSTAync(q, new
                {
                    IdPrdsTrnrSbjct = oT.IdPrdsTrnrSbjct,
                    IdWorker = oT.IdWorker
                });
                oT.Id = id;
                return oT;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CTrainersAvailable> SetTrainersAvailablesByAsync(CTrainersAvailable oTA)
        {
            try
            {
                string q = @"INSERT INTO [dbo].[tTrainersAvailable]
                                           (
                                            IdSubject
                                           ,IdTrainer
                                           ,IsItAvailabe
                                           ,Priority)
                                OUTPUT INSERTED.Id
                                     VALUES
                                          (
                                           @IdSubject,
                                           @IdTrainer,
                                           @IsItAvailabe,
                                           @Priority)";
                var id = await _igcta.GetQrySnglDataFRSTAync(q,
                    new
                    {
                        @IdSubject = oTA.IdSubject,
                        @IdTrainer = oTA.IdTrainer,
                        @IsItAvailabe = oTA.IsItAvailabe,
                        @Priority = oTA.Priority
                    });
                oTA.Id = id;
                return oTA;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CSubject> UpdateSubject(CSubject oSbjct)
        {
            try
            {
                var q = @"UPDATE [dbo].[tSubjects] Set [Name] = @Name, [IsActive] = @IsActive WHERE Id = @Id";
                var res = await _igcs.GetQrySnglDataAync(q, new { Id = oSbjct.Id, Name = oSbjct.Name, IsActive = oSbjct.IsActive });
                return oSbjct;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
