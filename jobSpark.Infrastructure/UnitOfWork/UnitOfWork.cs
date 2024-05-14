using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;


namespace jobSpark.Infrastructure.UnitOfWork
{
    public class unitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; set; }

        public IVacancyRepository Vacancies { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ICompanyRepository Companies { get; private set; }


        public ISkillRepository Skills { get; private set; }

        public IWorkingHistoryRepository WorkingHistories { get; private set; }

        public IApplicantRepository applicants { get; }

        public IApplicantVacancyRepository ApplicantVacancies { get; }

        public UserManager<User> _userManager { get; }

        public RoleManager<IdentityRole> _roleManager { get; }

        public IProjectRepository Projects { get; private set; }

        public IAchievementRepository Achievements { get; private set; }

        public unitOfWork(
            ApplicationDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            Vacancies = new VacancyRepository(_context);

            Categories = new CategoryRepository(_context);

            Companies = new CompanyRepository(_context);

            Skills = new SkillRepository(_context);
            WorkingHistories = new WorkingHistoryRepository(_context);

            applicants = new ApplicantRepository(_context);

            ApplicantVacancies = new ApplicantVacancyRepository(_context);
            _userManager = userManager;
            _roleManager = roleManager;

            Projects = new ProjectRepository(_context);
            Achievements = new AchievementRepository(_context);




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

