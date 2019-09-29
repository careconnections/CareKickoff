using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;
using CareKickoff.Persistence.Records;
using Microsoft.EntityFrameworkCore;

namespace CareKickoff.Persistence.Repositories {
    public class AuthorizationRepository : RepositoryBase, IAuthorizationRepository {
        public AuthorizationRepository(ApplicationDbContext ctx) : base(ctx) { }
        
        public void Create(AuthorizationEntity entity) {
            ValidateEntity(entity);
            
            DataContext.Add(AuthorizationRecord.FromEntity(entity));
            DataContext.SaveChanges();
        }

        public void Delete(AuthorizationEntity entity) {
            var record = DataContext.Authorizations
                .Single(_ => _.Id == entity.Id);

            DataContext.Authorizations.Remove(record);
            DataContext.SaveChanges();
        }

        public AuthorizationEntity[] GetByEmployeeId(int id) {
            return DataContext.Authorizations
                .Where(_ => _.EmployeeId == id)
                .Include(_ => _.Client)
                .Include(_ => _.Employee)
                .Select(_ => _.ToEntity())
                .ToArray();
        }

        public AuthorizationEntity[] GetByClientId(int id) {
            return DataContext.Authorizations
                .Where(_ => _.ClientId == id)
                .Include(_ => _.Client)
                .Include(_ => _.Employee)
                .Select(_ => _.ToEntity())
                .ToArray();
        }

        public AuthorizationEntity[] GetAll() {
            return DataContext.Authorizations
                .OrderBy(_ => _.Id)
                .Include(_ => _.Client)
                .Include(_ => _.Employee)
                .Select(_ => _.ToEntity())
                .ToArray();
        }
        
        private static void ValidateEntity(AuthorizationEntity entity) {
            EnsureValidEntity(entity);
        }
    }
}