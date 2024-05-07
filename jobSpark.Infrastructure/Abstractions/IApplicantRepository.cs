using jobSpark.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jobSpark.Domain.Entities;

namespace jobSpark.Infrastructure.Abstractions
{
    public interface IApplicantRepository : IGenericRepository<Applicant>
    {
    }
}
