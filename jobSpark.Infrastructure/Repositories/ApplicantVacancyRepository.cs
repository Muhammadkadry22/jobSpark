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
    public class ApplicantVacancyRepository : GenericRepository<ApplicantVacancy>, IApplicantVacancyRepository
    {
        public readonly DbSet<ApplicantVacancy> _applicants;
        public ApplicantVacancyRepository(ApplicationDbContext context) : base(context)
        {
            _applicants = context.Set<ApplicantVacancy>();
        }
    }
}
