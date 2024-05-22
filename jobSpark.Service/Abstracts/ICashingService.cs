using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.Abstracts
{
    public interface ICashingService
    {
        Task<T> GetData<T>(string key);
        Task<bool> setData<T>(string key,T value,TimeSpan expiryTime);
        Task<bool> removeData (string key);
    }
}
