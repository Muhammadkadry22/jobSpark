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
        public readonly DbSet<Applicant> _applicantsList;
        public ApplicantVacancyRepository(ApplicationDbContext context) : base(context)
        {
            _applicants = context.Set<ApplicantVacancy>();
            _applicantsList = context.Set<Applicant>();
        }

        public async Task<List<Applicant>> GetApplicantsByVacancyId(int vacancyId)
        {
            var applicantsID = await _applicants
                                    .Where(m => m.VacancyId == vacancyId)
                                    .Select(m => m.ApplicantId)
                                    .ToListAsync();

            var applicants = await _applicantsList
                                   .Where(a => applicantsID.Contains(a.Id))
                                   .ToListAsync();
            return applicants;
        }
    }
}
