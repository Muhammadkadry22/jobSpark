using jobSpark.Domain.Entities;
using jobSpark.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password , string Role );
        public Task<JwtAuthResult> GetJWTToken(User user);
        public Task<string> getUserIdAsync();
    }
}
