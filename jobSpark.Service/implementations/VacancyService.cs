using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.implementations
{
    public class VacancyService : IVacancyService
    {
       
        private readonly IUnitOfWork unitOfWork;

        public VacancyService(IUnitOfWork unitOfWork)
        {
          
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Vacancy>> GetVacancyListAsync()
        {
            return await unitOfWork.Vacancies.GetVacanciesAsync();
        }
        public async Task<Vacancy> GetVacancyByIdAsync(int id)
        {
            return await unitOfWork.Vacancies.GetByIdAsync(id);
        }
    }
}
