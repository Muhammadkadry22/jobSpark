using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.InfrastructureBases;

namespace jobSpark.Infrastructure.Abstractions
{
    public interface IVacancyRepository : IGenericRepository<Vacancy>
    {

        public Task<List<Vacancy>> GetVacanciesAsync();



    }
}
