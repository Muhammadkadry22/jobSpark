using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.UnitOfWork
{
    public class unitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; set; }

        public IVacancyRepository Vacancies { get; private set; }

         public ICategoryRepository Categories { get; private set; }

        public ICompanyRepository Companies { get; }

        public IApplicantRepository applicants { get; }

       public UserManager<User> _userManager { get; }

       public RoleManager<IdentityRole> _roleManager { get; }

        public unitOfWork(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            Vacancies = new VacancyRepository(_context);

            Categories=new CategoryRepository(_context);

            Companies = new CompanyRepository(_context);
            applicants = new ApplicantRepository(_context);

            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
       
        

}

