using System;

using AutoMapper;

using Entities.DbContext;
using Entities.Models;
using Entities.Contracts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Repository.Repositories;

namespace ASP.NETTask.WebAPI.ExtensionsMethods
{
    /// <summary>
    /// ExtensionConfigureServices static class
    /// </summary>
    public static class ExtensionConfigureServices
    {
        /// <summary>
        /// ConfigureConfigureServicesInjuection method
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureConfigureServicesInjuection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChargingStationsDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ChargingStationsConnectionString")));
            services.AddScoped<ILocationRepository<BaseClass>, LocationRepository>();
            services.AddSingleton<IMessageBroker, MessageBroker>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
