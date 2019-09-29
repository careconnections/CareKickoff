using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using CareKickoff.Persistence.Repositories;

namespace CareKickoff.Infrastructure.Factories {
    public static class ClientServiceFactory {
        public static ClientService Create(ApplicationDbContext ctx) {
            return new ClientService(new ClientRepository(ctx));
        }
    }
}