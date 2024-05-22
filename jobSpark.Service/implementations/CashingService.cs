using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Extensions.Configuration;
using jobSpark.Service.Abstracts;
using StackExchange.Redis;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace jobSpark.Service.implementations
{
    public class CashingService : ICashingService
    {
        private IDatabase _cashDB;
        public CashingService(IConfiguration configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration.GetSection("CashingConnectionString:redisConnection").Value); 
            _cashDB =redis.GetDatabase();
        }
        public async Task<T> GetData<T>(string key)
        {
            var value = await _cashDB.StringGetAsync(key);
            if(!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);
            return default(T);            
        }


        public async Task<bool> setData<T>(string key, T value, TimeSpan expiryTime)
        {
            return await _cashDB.StringSetAsync(key,JsonSerializer.Serialize(value), expiryTime);
        }

        public async Task<bool> removeData(string key)
        {
            var isExist = await _cashDB.KeyExistsAsync(key);
            if(isExist)
                return await _cashDB.KeyDeleteAsync(key);
            return false;
        }
    }
}
