using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Interfaces;
using MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Chps.Users.Services
{
    public class UserJWTSrvc //: IUserJWTSrvc
    {
        private IList<Claim> claims;
        public UserJWTSrvc() { }
        public async Task<CUsrTkn> GetUserJWTAuth(CUsrInf oUI)
        {
            try
            {
                if (oUI.K == "validating")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "LogIn"));
                    claims.Add(new Claim("IdWorker", oUI.Id));
                    claims.Add(new Claim(ClaimTypes.Name, "LogInSys"));
                    claims.Add(new Claim(ClaimTypes.Role, "LogInAdminSys"));
                    claims.Add(new Claim("EMail", oUI.U));
                    claims.Add(new Claim("DeviceId", oUI.IdDevice));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
                else if(oUI.K == "StartRequestSignUp")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "LogIn"));
                    claims.Add(new Claim("IdWorker", oUI.Id));
                    claims.Add(new Claim(ClaimTypes.Name, "LogInSys"));
                    claims.Add(new Claim(ClaimTypes.Role, "LogInAdminSys"));
                    claims.Add(new Claim("EMail", oUI.U));
                    claims.Add(new Claim("DeviceId", oUI.IdDevice));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
                else if(oUI.K == "LogInService")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "LogIn"));
                    claims.Add(new Claim("IdWorker", oUI.Id));
                    claims.Add(new Claim(ClaimTypes.Name, "LogInSys"));
                    claims.Add(new Claim(ClaimTypes.Role, "LogInAdminSys"));
                    claims.Add(new Claim("EMail", oUI.U));
                    claims.Add(new Claim("DeviceId", oUI.IdDevice));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
                else if(oUI.K == "LogInServiceCnfrmd")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "LogIn"));
                    claims.Add(new Claim("IdWorker", oUI.Id));
                    claims.Add(new Claim(ClaimTypes.Name, "LogInSys"));
                    claims.Add(new Claim(ClaimTypes.Role, "LogInAdminSys"));
                    claims.Add(new Claim("EMail", oUI.U));
                    claims.Add(new Claim("DeviceId", oUI.IdDevice));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
                else if (oUI.K == "P3AIndex")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "P3A"));
                    claims.Add(new Claim(ClaimTypes.Name, "P3ASys"));
                    claims.Add(new Claim(ClaimTypes.Role, "P3AAdminSys"));
                    claims.Add(new Claim("UserName", oUI.U));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
                else if (oUI.K == "SACIndex")
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim("AppKey", "SAC"));
                    claims.Add(new Claim(ClaimTypes.Name, "SACSys"));
                    claims.Add(new Claim(ClaimTypes.Role, "SACAdminSys"));
                    claims.Add(new Claim("UserName", oUI.U));
                    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
                    return rslt;
                }
				else if (oUI.K == "SACAnonimousUser")
				{
					claims = new List<Claim>();
					claims.Add(new Claim("AppKey", "SAC"));
					claims.Add(new Claim(ClaimTypes.Name, "SACSys"));
					claims.Add(new Claim(ClaimTypes.Role, "SACAnnmsUsr"));
					claims.Add(new Claim("UserName", oUI.U));
					var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(5));
					return rslt;
				}
				else if (oUI.K == "webassembly")
                {
                    if (oUI.U == "p3a.test@shyfpchiapas.gob.mx" && oUI.P == "123qwe")
                    {
                        claims = new List<Claim>();
                        claims.Add(new Claim("AppKey", "P3A"));
                        claims.Add(new Claim(ClaimTypes.Name, "P3ASysAdmin"));
                        claims.Add(new Claim(ClaimTypes.Role, "P3AAdminSysEMail"));
                        claims.Add(new Claim("UserName", oUI.U));
                        var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(15));
                        return rslt;
                    }
                    else if (oUI.U == "arianna.geg@hotmail.com" && oUI.P == "123qwe")
                    {
                        claims = new List<Claim>();
                        claims.Add(new Claim("AppKey", "SAC"));
                        claims.Add(new Claim(ClaimTypes.Name, "SACSysAdmin"));
                        claims.Add(new Claim(ClaimTypes.Role, "SACAdminSysEMail"));
                        claims.Add(new Claim("UserName", oUI.U));
                        var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(15));
                        return rslt;
                    }
					else if (oUI.U == "rudyard.matuz@gmail.com" && oUI.P == "123qwe")
					{
						claims = new List<Claim>();
						claims.Add(new Claim("AppKey", "DEV"));
						claims.Add(new Claim(ClaimTypes.Name, "DEVSysAdmin"));
						claims.Add(new Claim(ClaimTypes.Role, "DEVRootAdmin"));
						claims.Add(new Claim("UserName", oUI.U));
						var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(15));
						return rslt;
						//var rt = await _idc.GetStringValueAsync(oUI.U);
						////_irs.GetStringValueAsync(oUI.U);
						//if (oUI.P == rt)
						//{
						//    claims = new List<Claim>();
						//    claims.Add(new Claim("AppKey", "SICD"));
						//    claims.Add(new Claim(ClaimTypes.Name, "SIDC"));
						//    claims.Add(new Claim(ClaimTypes.Role, "SIDCTest"));
						//    claims.Add(new Claim("UserName", oUI.U));
						//    var rslt = await BuildJWT(claims, DateTime.Now.AddMinutes(15));
						//    return rslt;
						//}
					}
                    ///User Not Found
                    throw new Exception("Usuario no encontrado");
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<CUsrTkn> BuildJWT(IList<Claim> _claims, DateTime dtExprtn)
        {
            try
            {
                _claims.Add(new Claim(ClaimTypes.PrimarySid, JwtRegisteredClaimNames.UniqueName));
                _claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                //string stringKey = "0f304a3df8be62a4c74f0f2df6a7a834dcef8a5cd56d7e4bca94e75cc1b17dfc";
                string stringKey = "ASRDLUKAYSNADLRAKDSDNKJLRJNTLERJKNTELRKJNWLKJRNWELRJWERIWHERJLWENRWKLEJRNWE";
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(stringKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: "shyfp.dvlpr@gmail.com",
                   audience: "shyfp.dvlpr@gmail.com",
                   claims: _claims,
                   notBefore: DateTime.Now,
                   expires: dtExprtn,
                   signingCredentials: creds
                );

                var rslt = new CUsrTkn
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = dtExprtn
                };
                return await Task.FromResult(rslt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
