using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.Repositories
{
    public class WorkingHistoryRepository:GenericRepository<WorkingHistory>,IWorkingHistoryRepository
    {
        private readonly DbSet<WorkingHistory> _workingHistory;

        public WorkingHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _workingHistory = context.Set<WorkingHistory>();
        }
    }
}
