using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

       ApplicationDbContext _context { get; }

        IVacancyRepository Vacancies { get; }

        ICategoryRepository Categories { get; }

        ICompanyRepository Companies { get; }

        ISkillRepository Skills { get; }
        IWorkingHistoryRepository WorkingHistories { get; }
        IProjectRepository Projects { get; }
        IAchievementRepository Achievements { get; }
        IApplicantRepository applicants { get; }
       
        IApplicantVacancyRepository  ApplicantVacancies { get; }
        public UserManager<User> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        

        Task SaveChangesAsync();
    }
}
