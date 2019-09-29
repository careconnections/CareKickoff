using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using CareKickoff.Persistence.Repositories;

namespace CareKickoff.Infrastructure.Factories {
    public static class AuthorizationServiceFactory {
        public static AuthorizationService Create(ApplicationDbContext ctx) {
            return new AuthorizationService(new AuthorizationRepository(ctx));
        }
    }
}