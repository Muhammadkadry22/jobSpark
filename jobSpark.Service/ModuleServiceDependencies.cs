﻿using jobSpark.Service.Abstracts;
using jobSpark.Service.implementations;
using Microsoft.Extensions.DependencyInjection;

namespace jobSpark.Service
{
    public static class ModuleServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IVacancyService, VacancyService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();

            services.AddTransient<IApplicantUserService, ApplicantUserService>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<ICompanyUserService, CompanyUserService>();



            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISkillSevice, SkillSevice>();
            services.AddTransient<IWorkingHistoryService, WorkingHistoryService>();


            services.AddTransient<IApplicantVacancyService,ApplicantVacancyService>();
            services.AddTransient<IFileService, FileService>();


            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IAchievementService,AchievementService>();


            return services;
        }

    }
}
