using jobSpark.Domain.Entities;

namespace jobSpark.Service.Abstracts
{
    public interface IVacancyService
    {
        public Task<List<Vacancy>> GetVacancyListAsync();

        public Task<Vacancy> GetVacancyByIdAsync(int id);

        public Task<string> AddVacanyAsync(Vacancy vacancy);

        public IQueryable<Vacancy> GetVacanciesQuerable();

        public IQueryable<Vacancy> FilliterVacanciesPaginatedQuerable(string search);


    }
}
