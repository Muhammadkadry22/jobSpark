using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.UnitOfWork;
using jobSpark.Service.Abstracts;
using Microsoft.IdentityModel.Tokens;

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
            if (querable.IsNullOrEmpty())
            {
                return Enumerable.Empty<Vacancy>().AsQueryable();
            }
            if (search != null)
            {
                querable = querable.Where(x => x.Name.Contains(search) || x.Company.Name.Contains(search));
            }
            return querable;
        }



        public IQueryable<Applicant> GetApplicantsByVacanyIdPaginatedQuerable(int vacancyId)
        {
            var applicantVacncies = unitOfWork.ApplicantVacancies.GetTableNoTracking().AsQueryable().Where(v => v.VacancyId == vacancyId);
            var applicants = unitOfWork.applicants.GetTableNoTracking().AsQueryable();

            if (!applicants.IsNullOrEmpty() && !applicantVacncies.IsNullOrEmpty())
            {
                var query = from a in applicantVacncies
                            join b in applicants on a.ApplicantId equals b.Id
                            select new Applicant
                            {
                                Id = a.ApplicantId,
                                Name = b.Name,
                                Email = b.Email,
                                Phone = b.Phone,
                                Website = b.Website,
                                Cv = b.Cv,
                                Description = b.Description,
                                Brief = b.Brief,
                                GraduationYear = b.GraduationYear,
                                Country = b.Country,
                                Experience = b.Experience,
                                Certifications = b.Certifications,
                                Projects = b.Projects,
                                Skills = b.Skills,
                                WorkingHistories = b.WorkingHistories
                            };
                return query;
            }

            return Enumerable.Empty<Applicant>().AsQueryable();
        }


    }


}
