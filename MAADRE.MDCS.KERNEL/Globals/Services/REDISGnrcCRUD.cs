
using MAADRE.MDCSI.KERNEL.Globals.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.Globals.Services
{
    public class REDISGnrcCRUD<T> : IREDISGnrcCRUD<T>
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        IDistributedCache _idc;
        public REDISGnrcCRUD(IConnectionMultiplexer icmp)
        {
            _connectionMultiplexer = icmp;
        }

        public async Task<string> GetStringValueAsync(string k)
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                var ke = await db.KeyExistsAsync(k);
                if (ke)
                {
                    string c = await db.StringGetAsync(k);
                    return c;
                }
                else
                {
                    throw new Exception("No se encontró llave");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckKey(string k)
        {
            var db = _connectionMultiplexer.GetDatabase();
            var r = await db.KeyExistsAsync(k);
            return r;
        }

        public async Task<IQueryable<T>> GetQrybl(string k)
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                var ke = db.KeyExists(k);//await db.KeyExistsAsync(k);
                if (ke)
                {
                    //string c = await db.StringGetAsync(k);
                    string c = db.StringGet(k);
                    var oc = JsonSerializer.Deserialize<IEnumerable<T>>(c);
                    return oc.AsQueryable();
                }
                else 
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await Task.CompletedTask;
            }
        }

        public async Task SetTEAsync(string key, string srlzObj)
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                await db.StringSetAsync(key, srlzObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SetWTEAsync(string key, string value, DateTime expr)
        {
            try
            {
                if (await CheckKey(key))
                    await DeleteAsync(key);
                /*var lv = Encoding.UTF8.GetBytes(value);
                var options = new DistributedCacheEntryOptions()
                                    .SetAbsoluteExpiration(expr.AddMinutes(3))
                                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));*/
                var db = _connectionMultiplexer.GetDatabase();
                //await _idc.SetAsync(key, lv, options);
                //await db.StringSetAsync(key, value);
                //TimeSpan CurrentTime = DateTime.;//expr.TimeOfDay;
                await db.StringSetAsync(key, value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GetListSerializeAsync(string k)
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                return await db.StringGetAsync(k);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                var db = _connectionMultiplexer.GetDatabase();
                var res = await db.KeyDeleteAsync(key, CommandFlags.FireAndForget);
                //return await db.StringGetDeleteAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}