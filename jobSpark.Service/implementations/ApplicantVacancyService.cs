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
    public class ApplicantVacancyService : IApplicantVacancyService
    {
        private readonly IUnitOfWork unitOfWork;

        public ApplicantVacancyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddAppVacancyAsync(ApplicantVacancy appvacancyMapper)
        {
            await unitOfWork.ApplicantVacancies.AddAsync(appvacancyMapper);
            await unitOfWork.SaveChangesAsync();
            return "Added";

        }
    }
}
