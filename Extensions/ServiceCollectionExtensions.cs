using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetInterviewTask.Contracts;
using DotnetInterviewTask.Implementations;
using Mapster;
using MapsterMapper;


namespace DotnetInterviewTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Default.EnumMappingStrategy(EnumMappingStrategy.ByName);
            services.AddSingleton(config);
            services.AddTransient<IMapper, ServiceMapper>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            return services
                .AddScoped<IApplicationProgramRepository, ApplicationProgramRepository>()
                .AddScoped<IApplicationResponseRepository, ApplicationResponseRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            return services
                .AddScoped<IApplicationProgramService, ApplicationProgramService>()
                .AddScoped<IApplicationResponseService, ApplicationResponseService>();
        }
    }
}