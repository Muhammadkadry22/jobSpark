using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.Abstractions
{
    public interface IWorkingHistoryRepository:IGenericRepository<WorkingHistory>
    {
    }
}
