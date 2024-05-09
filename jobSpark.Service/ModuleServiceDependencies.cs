using jobSpark.Service.Abstracts;
using jobSpark.Service.implementations;
using Microsoft.Extensions.DependencyInjection;

namespace jobSpark.Service
{
    public static class ModuleServiceDependencies
    {

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            services.AddTransient<IApplicationUserService, ApplicationUserService>();
    
            return services;
        }

    }
}
