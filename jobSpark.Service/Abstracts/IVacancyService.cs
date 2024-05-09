using jobSpark.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.Abstracts
{
    public interface IVacancyService
    {
        public Task<List<Vacancy>> GetVacancyListAsync();

        public Task<Vacancy> GetVacancyByIdAsync(int id);

        public Task<string> AddVacany(Vacancy vacancy);

    }
}
