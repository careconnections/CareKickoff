using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using CareKickoff.Persistence.Repositories;

namespace CareKickoff.Infrastructure.Factories {
    public static class EmployeeServiceFactory {
        public static EmployeeService Create(ApplicationDbContext ctx) {
            return new EmployeeService(new EmployeeRepository(ctx));
        }
    }
}