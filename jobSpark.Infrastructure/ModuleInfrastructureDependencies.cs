using Azure;
using jobSpark.Domain.Entities;
using jobSpark.Infrastructure.Abstractions;
using jobSpark.Infrastructure.Context;
using jobSpark.Infrastructure.InfrastructureBases;
using jobSpark.Infrastructure.Repositories;
using jobSpark.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace jobSpark.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services )
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IVacancyRepository, VacancyRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IWorkingHistoryRepository, WorkingHistoryRepository>();   

            services.AddTransient<IApplicantVacancyRepository, ApplicantVacancyRepository>();

            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IAchievementRepository, AchievementRepository>();
            services.AddTransient<IVacancyApplicantRepository, VacancyApplicantRepository>();





            services.AddTransient<IUnitOfWork, unitOfWork>();

        



            return services;
        }


    }
}
