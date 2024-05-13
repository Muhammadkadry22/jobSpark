using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.implementations
{
    public class WorkingHistoryService : IWorkingHistoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public WorkingHistoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddWorkingHistoryAsync(WorkingHistory workingHistory)
        {
           await unitOfWork.WorkingHistories.AddAsync(workingHistory);
            await unitOfWork.SaveChangesAsync();
            return "added";

        }
    }
}
