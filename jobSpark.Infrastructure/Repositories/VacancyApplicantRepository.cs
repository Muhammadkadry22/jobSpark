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
    public class VacancyApplicantRepository : GenericRepository<ApplicantVacancy>, IVacancyApplicantRepository
    {
        private readonly DbSet<ApplicantVacancy> _ApplicantVacancy;
        public VacancyApplicantRepository(ApplicationDbContext context) : base(context)
        {
            _ApplicantVacancy = context.Set<ApplicantVacancy>();
        }
    }
}
