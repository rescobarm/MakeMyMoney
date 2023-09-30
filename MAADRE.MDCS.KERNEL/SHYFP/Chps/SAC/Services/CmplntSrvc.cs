using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Models;
using MAADRE.MDCSI.KERNEL.SHYFP.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.SAC.Services
{
    public class CmplntSrvc : ICmplntSrvc
    {
        private readonly IDbDMGnrcCRUD<COmplaint> _icp;
		private readonly IDbDMGnrcCRUD<CCmbBxOptns> _gcbc;
        private readonly IDbDMGnrcCRUD<string> _ifl;
        private readonly IDbDMGnrcCRUD<Trabajador> _iss;

        public CmplntSrvc(IDbDMGnrcCRUD<COmplaint> icp, 
            IDbDMGnrcCRUD<CCmbBxOptns> gcbc,
            IDbDMGnrcCRUD<string> ifl,
            IDbDMGnrcCRUD<Trabajador> iss)
        {
            _icp = icp;
            _gcbc = gcbc;
            _ifl = ifl;
            _iss = iss;
        }

        public async Task<string> GetTest()
        {
            try
            {
                string q = @"select top(10) * from tblTrabajador";
                object p = new { };
                var _sys = await _iss.GetQryCllctnDataAync_sicdb(q, new { });
                var obj = JsonSerializer.Serialize(_sys);
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<IEnumerable<CCmbBxOptns>> GetCCmbBxOptns(string q, object p)
        {
            try
            {
                var resp = await _gcbc.GetQryCllctnDataAync(q, p);
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region CRUD COMPLAINT
        public async Task<COmplaint> SaveRecordByAdmin(COmplaint cmplnt)
        {
            try
            {
                string qf = @"SELECT concat(substring(cast(year(getdate()) as nvarchar(4)), 1, 4), '-E-',(count(folio_system) + 1)) As NoFolio 
		                        FROM tRecords
			                        Where 
										SUBSTRING(folio_system, 1, 4) like substring(cast(year(getdate()) as nvarchar(4)), 1, 4)
									And
										SUBSTRING(folio_system, 5, 3) like '-E-';";

                string folio_sys = await _ifl.GetQrySnglDataAync(qf, new { });

                string q = @"Insert Into tRecords(
                                folio_system,
                                folio_turno,
                                expediente,
                                id_falta, 
                                id_status, 
                                demandante, 
                                fecha_denuncia, 
                                hora_denuncia, 
                                lugar_denuncia, 
                                institucion, 
                                tramite, 
                                narracion, 
                                id_programa, 
                                persona_demandada, 
                                testigo,
                                dcmnts_spprtng_claim,
                                correo, 
                                celular, 
                                esAnonimo, 
                                particular_servidor, 
                                requiereMedida, 
                                id_dependencia, 
                                curp, 
                                id_falta_administrativa, 
                                nombreDemandante, 
                                paternoDemandante, 
                                maternoDemandante, 
                                sexoDemandante, 
                                edadDemandante, 
                                id_escolaridad, 
                                id_ocupacion, 
                                representa_a, 
                                codigo,
                                IdConductCatalog,
                                IdReceivingMedium,
                                revisado,
                                IdLawyer,
                                IdTurnedTo                                
                            ) OUTPUT INSERTED.Id values (
                                @FolioSys,
                                @FolioTrn,
                                @Expediente,
                                @Id_falta, 
                                @Id_status, 
                                @Demandante, 
                                @Fecha_denuncia, 
                                @Hora_denuncia, 
                                @Lugar_denuncia, 
                                @Institucion, 
                                @Tramite, 
                                @Narracion, 
                                @Id_programa, 
                                @Persona_demandada, 
                                @Testigo,
                                @DcmntsSpprtngClaim,
                                @Correo, 
                                @Celular, 
                                @EsAnonimo, 
                                @Particular_servidor, 
                                @RequiereMedida, 
                                @Id_dependencia, 
                                @Curp, 
                                @Id_falta_administrativa, 
                                @NombreDemandante, 
                                @PaternoDemandante, 
                                @MaternoDemandante, 
                                @SexoDemandante, 
                                @EdadDemandante, 
                                @Id_escolaridad, 
                                @Id_ocupacion, 
                                @Representa_a, 
                                @Codigo,
                                @IdConductCatalog,
                                @IdReceivingMedium,
                                @Revisado,
                                @IdLawyer,
                                @IdTurnedTo);";
                object p = new
                {
                    @FolioSys = folio_sys,
                    @FolioTrn = cmplnt.folio_turno,
                    @Expediente = cmplnt.expediente,
                    @Id_falta = cmplnt.id_falta,
                    @Id_status = cmplnt.id_status,
                    @Demandante = cmplnt.demandante,
                    @Fecha_denuncia = cmplnt.fecha_denuncia,
                    @Hora_denuncia = cmplnt.hora_denuncia,
                    @Lugar_denuncia = cmplnt.lugar_denuncia,
                    @Institucion = cmplnt.institucion,
                    @Tramite = cmplnt.tramite,
                    @Narracion = cmplnt.narracion,
                    @Id_programa = cmplnt.id_programa,
                    @Persona_demandada = cmplnt.persona_demandada,
                    @Testigo = cmplnt.testigo,
                    @DcmntsSpprtngClaim = cmplnt.dcmnts_spprtng_claim,
                    @Correo = cmplnt.correo,
                    @Celular = cmplnt.celular,
                    @EsAnonimo = cmplnt.esAnonimo,
                    @Particular_servidor = cmplnt.particular_servidor,
                    @RequiereMedida = cmplnt.requiereMedida,
                    @Id_dependencia = cmplnt.id_dependencia,
                    @Curp = cmplnt.curp,
                    @Id_falta_administrativa = cmplnt.id_falta_administrativa,
                    @NombreDemandante = cmplnt.nombreDemandante,
                    @PaternoDemandante = cmplnt.paternoDemandante,
                    @MaternoDemandante = cmplnt.maternoDemandante,
                    @SexoDemandante = cmplnt.sexoDemandante,
                    @EdadDemandante = cmplnt.edadDemandante,
                    @Id_escolaridad = cmplnt.id_escolaridad,
                    @Id_ocupacion = cmplnt.id_ocupacion,
                    @Representa_a = cmplnt.representa_a,
                    @Codigo = cmplnt.codigo,
                    @IdConductCatalog = cmplnt.IdConductCatalog,
                    @IdReceivingMedium = cmplnt.IdReceivingMedium,
                    @Revisado = cmplnt.revisado,
                    @IdLawyer = cmplnt.IdLawyer,
                    @IdTurnedTo = cmplnt.IdTurnedTo
                };
                //var resp1 = await ICmbBxOptnsSrvc.SetInsertDataAsync(q, p);
                int id = await _icp.GetQrySnglDataFRSTAync(q, p);
                cmplnt.id = id;
                cmplnt.folio_system = folio_sys;
                return await Task.FromResult(cmplnt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateRecordByAdmin(COmplaint cmplnt)
        {
            try
            {
                string q = @"Update tRecords Set
                                folio_turno = @FolioTrn,
                                expediente = @Expediente,
                                id_falta = @Id_falta, 
                                id_status = @Id_status, 
                                demandante = @Demandante, 
                                fecha_denuncia = @Fecha_denuncia, 
                                hora_denuncia = @Hora_denuncia, 
                                lugar_denuncia = @Lugar_denuncia, 
                                institucion = @Institucion, 
                                tramite = @Tramite,
                                narracion = @Narracion, 
                                id_programa = @Id_programa,
                                persona_demandada = @Persona_demandada,
                                testigo = @Testigo,
                                dcmnts_spprtng_claim = @DcmntsSpprtngClaim,
                                correo = @Correo, 
                                celular = @Celular, 
                                esAnonimo = @EsAnonimo,
                                particular_servidor = @Particular_servidor,
                                requiereMedida = @RequiereMedida, 
                                id_dependencia = @Id_dependencia, 
                                curp = @Curp,
                                id_falta_administrativa = @Id_falta_administrativa,
                                nombreDemandante = @NombreDemandante,
                                paternoDemandante = @PaternoDemandante,
                                maternoDemandante = @MaternoDemandante,
                                sexoDemandante = @SexoDemandante,
                                edadDemandante = @EdadDemandante,
                                id_escolaridad = @Id_escolaridad,
                                id_ocupacion = @Id_ocupacion,
                                representa_a = @Representa_a,
                                codigo = @Codigo,
                                IdConductCatalog = @IdConductCatalog,
                                IdReceivingMedium = @IdReceivingMedium,
                                revisado = @Revisado,
                                IdLawyer = @IdLawyer,
                                IdTurnedTo = @IdTurnedTo
                                    Where id = @IdRecord;";
                object p = new
                {
                    @FolioTrn = cmplnt.folio_turno,
                    @Expediente = cmplnt.expediente,
                    @Id_falta = cmplnt.id_falta,
                    @Id_status = cmplnt.id_status,
                    @Demandante = cmplnt.demandante,
                    @Fecha_denuncia = cmplnt.fecha_denuncia,
                    @Hora_denuncia = cmplnt.hora_denuncia,
                    @Lugar_denuncia = cmplnt.lugar_denuncia,
                    @Institucion = cmplnt.institucion,
                    @Tramite = cmplnt.tramite,
                    @Narracion = cmplnt.narracion,
                    @Id_programa = cmplnt.id_programa,
                    @Persona_demandada = cmplnt.persona_demandada,
                    @Testigo = cmplnt.testigo,
                    @DcmntsSpprtngClaim = cmplnt.dcmnts_spprtng_claim,
                    @Correo = cmplnt.correo,
                    @Celular = cmplnt.celular,
                    @EsAnonimo = cmplnt.esAnonimo,
                    @Particular_servidor = cmplnt.particular_servidor,
                    @RequiereMedida = cmplnt.requiereMedida,
                    @Id_dependencia = cmplnt.id_dependencia,
                    @Curp = cmplnt.curp,
                    @Id_falta_administrativa = cmplnt.id_falta_administrativa,
                    @NombreDemandante = cmplnt.nombreDemandante,
                    @PaternoDemandante = cmplnt.paternoDemandante,
                    @MaternoDemandante = cmplnt.maternoDemandante,
                    @SexoDemandante = cmplnt.sexoDemandante,
                    @EdadDemandante = cmplnt.edadDemandante,
                    @Id_escolaridad = cmplnt.id_escolaridad,
                    @Id_ocupacion = cmplnt.id_ocupacion,
                    @Representa_a = cmplnt.representa_a,
                    @Codigo = cmplnt.codigo,
                    @IdConductCatalog = cmplnt.IdConductCatalog,
                    @IdReceivingMedium = cmplnt.IdReceivingMedium,
                    @Revisado = cmplnt.revisado,
                    @IdLawyer = cmplnt.IdLawyer,
                    @IdTurnedTo = cmplnt.IdTurnedTo,
                    @IdRecord = cmplnt.id
                };
                //var resp1 = await ICmbBxOptnsSrvc.SetInsertDataAsync(q, p);
                var resp = await _icp.SetInsertDataAsync(q, p);
                //.SetQrySnglDataAsync(q, p);
                /*await Task.Run(async () => {
					await OnSendEmail(folio_sys, cmplnt.correo);
				});*/

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
#endregion

        public async Task<IEnumerable<COmplaint>> GetRecordsAsync(string opt)
        {
            try
            {
                /*string q = @"SELECT TOP (200) id, folio_system, folio, id_falta, id_status, demandante, fecha_denuncia, hora_denuncia, 
                                lugar_denuncia, institucion, tramite, narracion, id_programa, persona_demandada, testigo, 
                                dcmnts_spprtng_claim, correo, celular, esAnonimo, particular_servidor, requiereMedida, 
                                id_dependencia, curp, id_falta_administrativa, nombreDemandante, paternoDemandante, 
                                maternoDemandante, sexoDemandante, edadDemandante, id_escolaridad, id_ocupacion, 
                                id_municipality_wtetp, id_government_agency, representa_a, codigo, revisado, created_at, 
                                updated_at, deleted_at
                        FROM  tRecords";*/
                string q = string.Empty;
                object p = new { };
                if (opt == "all")
                    q = @"SELECT TOP (10) * FROM  tRecords order by id desc";
                else
                {
                    p = new { em = opt };
                    q = @"SELECT * FROM  tRecords where correo like @em order by id desc";
                }
                var resp = await _icp.GetQryCllctnDataAync(q, p);
                //ICmbBxOptnsSrvc.GetMySQLQueryAync(q, p);
                //var ok = new List<CCmbBxOptns>();
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		public async Task<IEnumerable<CCmbBxOptns>> GetEntities()
		{
            try
            {
				string q = @"Select CVE_ENT as Id, NOM_ENT as value, isActive From cMunicipalities 
                                group by CVE_ENT, NOM_ENT, isActive
                                    ORDER BY NOM_ENT;";
				object p = new { };
				var rsp = await GetCCmbBxOptns(q, p);
                return rsp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not find {ex.Message}");
            }
		}
        public async Task<IEnumerable<CCmbBxOptns>> GetGovAgency()
        {
            try
            {
                string q = @"Select Id as id, Description As value, isActive from (
                                Select Id, Description, isActive From cGovernmentAgencies Where AdministrativeOrganismType != 'H. Ayuntamiento'
                                    union all
                            	Select Id, CONCAT('H. Ayuntamiento de ', Description) As Description, isActive From cGovernmentAgencies Where AdministrativeOrganismType = 'H. Ayuntamiento'
                            ) T";
                object p = new { };
                var rsp = await GetCCmbBxOptns(q, p);
                return rsp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not find {ex.Message}");
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetPositions()
        {
            try
            {
                string q = @"Select Id, Description as value, isActive From cJobAssignments;";
                object p = new { };
                var rsp = await GetCCmbBxOptns(q, p);
                return rsp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not find {ex.Message}");
            }
        }
        public async Task<IEnumerable<CCmbBxOptns>> GetEducation()
        {
            try
            {
                string q = @"Select Id, Description as value, isActive From cScholarships;";
                object p = new { };
                var rsp = await GetCCmbBxOptns(q, p);
                return rsp;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not find {ex.Message}");
            }
        }
        
        public async Task<COmplaint> GetRecordBy(int idRecord)
        {
            try
            {
                string q = @"SELECT TOP (1) * FROM  tRecords Where id = @IdRecord order by id desc";
                object p = new { @IdRecord = idRecord };
                var resp = await _icp.GetQrySnglDataAync(q, p);
                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		public async Task<IEnumerable<CCmbBxOptns>> GetCatalogs(string opt, string ce)
		{
			try
			{
				string q = string.Empty;
				object p = new { };
				switch (opt)
				{
                    case "mncps":
                        p = new { CVE = ce };
                        q = @"Select CVE_ENT as Id, NOM_MUN as value, isActive From cMunicipalities Where CVE_ENT = @CVE 
                                group by CVE_ENT, NOM_MUN, isActive
                                    ORDER BY NOM_MUN;";
                        break;
                    case "dpndncs":
						q = @"Select Id as id, Description As value, isActive from (
                                Select Id, Description, isActive From cGovernmentAgencies Where AdministrativeOrganismType != 'H. Ayuntamiento'
                                    union all
                            	Select Id, CONCAT('H. Ayuntamiento de ', Description) As Description, isActive From cGovernmentAgencies Where AdministrativeOrganismType = 'H. Ayuntamiento'
                            ) T";
						break;
					case "ntts":
						q = @"Select CVE_ENT as Id, NOM_ENT as value, isActive From cMunicipalities 
                                group by CVE_ENT, NOM_ENT, isActive
                                    ORDER BY NOM_ENT;";
						break;
					case "ppf":
						q = "Select Id, Description as value, isActive From cGovernmentPrograms;";
						break;
					case "schlrshp":
						q = "Select Id, Description as value, isActive From cScholarships;";
						break;
					case "ocptns":
						q = "Select Id, Description as value, isActive From cActivities;";
						break;
                    case "admoffs":
						q = "Select Id, Description as value, isActive From cAdministrativeOffenses Order By Description asc;";
						break;
					case "crgs":
						q = "Select Id, Description as value, isActive From cJobAssignments;";
						break;
					case "lclts":
						p = new { CVE = ce };
						q = @"Select CVE_LOC as Id, NOM_LOC as value, isActive From cMunicipalities Where REPLACE(LTRIM(REPLACE(CVE_MUN, '0', ' ')),' ', '0') like @CVE
                                group by CVE_LOC, NOM_LOC, isActive
                                    ORDER BY NOM_LOC;";
						break;
				}

                var resp = await GetCCmbBxOptns(q, p);
				return resp;
			}
			catch (Exception ex)
			{
                throw ex;
			}
		}

        public Task<string> PostComplaint(COmplaint obj)
        {
            throw new NotImplementedException();
        }
        /**********************************************************/


        public Task<IEnumerable<CCmbBxOptns>> GetAdministrativeOffenses()
        {
           throw new NotImplementedException();
        }        

        public Task<IEnumerable<CCmbBxOptns>> GetFederalPublicProgram()
        {
            throw new NotImplementedException();
        }

        

        public Task<IEnumerable<CCmbBxOptns>> GetLocalities(string ce)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CCmbBxOptns>> GetMunicipalities()
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
