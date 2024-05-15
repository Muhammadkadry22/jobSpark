using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;

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

        public async Task<string> AddVacanyAsync(Vacancy vacancy)
        {
            await unitOfWork.Vacancies.AddAsync(vacancy);
            await unitOfWork.SaveChangesAsync();
            return "Added";

        }

        public IQueryable<Vacancy> GetVacanciesQuerable()
        {
            return unitOfWork.Vacancies.GetTableNoTracking().AsQueryable();
        }

        public IQueryable<Vacancy> FilliterVacanciesPaginatedQuerable(string search)
        {
            var querable = unitOfWork.Vacancies.GetTableNoTracking().AsQueryable();
            if (search != null)
            {
                querable = querable.Where(x => x.Name.Contains(search) || x.Company.Name.Contains(search));
            }
            return querable;
        }
    }


}
