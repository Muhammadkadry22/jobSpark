using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.Abstracts
{
    public interface IAchievementService
    {
        public Task<string> AddAchievementAsync(Achievement achievement);
    }
}
