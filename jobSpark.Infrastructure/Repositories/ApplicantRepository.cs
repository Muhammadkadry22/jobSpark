using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.InfrastructureBases;
namespace jobSpark.Infrastructure.Repositories
{
    public class ApplicantRepository : GenericRepository<Applicant>,IApplicantRepository
    {
        
        public ApplicantRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
