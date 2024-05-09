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
    public class CompanyRepository : GenericRepository<Company>,ICompanyRepository
    {
        private readonly DbSet<Company> _companies;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _companies = context.Set<Company>();
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _companies.ToListAsync();
        }
    }
}
