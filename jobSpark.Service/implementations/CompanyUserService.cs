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
     public class CompanyUserService : ICompanyUserService
    {
        public readonly IUnitOfWork unitOfWork;
        public CompanyUserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> AddCompany(Company company)
        {
            var res = unitOfWork._userManager.Users.FirstOrDefault(u => u.Email == company.Email);
            if (res != null)
            {
                company.UserId = res.Id;
            }
            await unitOfWork.Companies.AddAsync(company);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }
    }
}
