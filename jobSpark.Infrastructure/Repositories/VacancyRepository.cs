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
    public class VacancyRepository : GenericRepository<Vacancy>, IVacancyRepository
    {
        private readonly DbSet<Vacancy> _vacancies;
        public VacancyRepository(ApplicationDbContext context) : base(context)
        {
            _vacancies = context.Set<Vacancy>();
        }

        public async Task<List<Vacancy>> GetVacanciesAsync() //with its company "Becareful if using with includes in GR"
        {
            return await _vacancies.ToListAsync();
        }
    }
}
