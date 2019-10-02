using System;
using CareKickoff.Domain.Interfaces.Repositories;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using CareKickoff.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CareKickoff.Specification.Helpers {
    internal static class DependencyInjector {
        private const string DatabaseFileName = "unit-tests.db";

        public static T GetService<T>() {
            return (T) GetServiceProvider().GetService(typeof(T));
        }
        
        private static IServiceProvider GetServiceProvider() {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlite($"Data Source={DatabaseFileName}")
            );

            services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
            services.AddTransient(typeof(IAuthorizationRepository), typeof(AuthorizationRepository));

            services.AddTransient(typeof(EmployeeService), typeof(EmployeeService));
            services.AddTransient(typeof(ClientService), typeof(ClientService));
            services.AddTransient(typeof(AuthorizationService), typeof(AuthorizationService));
            
            return services.BuildServiceProvider();
        }
    }
}