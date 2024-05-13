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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> GetCompanyByUserId(string userId)
        {
           return  unitOfWork.Companies.FindAsync(u=>u.UserId == userId).Result.Id;
        }

        public async Task<List<Company>> GetCompanyListAsync()
        {
            var companies = await unitOfWork.Companies.GetAllAsync();
            return companies.ToList(); 
                
        }
    }
}
