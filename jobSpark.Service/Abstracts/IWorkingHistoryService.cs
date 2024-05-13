using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.Abstracts
{
    public interface IWorkingHistoryService
    {
        public Task<string> AddWorkingHistoryAsync(WorkingHistory workingHistory);
    }
}
