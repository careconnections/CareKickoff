using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;
using CareKickoff.Persistence.Records;
using Microsoft.EntityFrameworkCore;

namespace CareKickoff.Persistence.Repositories {
    public class ClientRepository : RepositoryBase, IClientRepository {
        public ClientRepository(ApplicationDbContext ctx) : base(ctx) { }
        public void Create(ClientEntity entity) {
            ValidateEntity(entity);
            
            DataContext.Add(ClientRecord.FromEntity(entity));
            DataContext.SaveChanges();
        }

        public void Delete(ClientEntity entity) {
            var record = GetClientById(entity.Id);
            DataContext.Clients.Remove(record);
            DataContext.SaveChanges();
        }

        public ClientEntity GetById(int id) {
            return GetClientById(id).ToEntity();
        }

        public ClientEntity[] GetAll() {
            return DataContext.Clients
                .OrderBy(_ => _.Id)
                .Include(_ => _.Careplans)
                .Include(_ => _.Authorizations)
                .ThenInclude(_ => _.Employee)
                .Select(_ => _.ToEntity())
                .ToArray();
        }
        
        private ClientRecord GetClientById(int id) {
            return DataContext.Clients
                .Include(_ => _.Careplans)
                .Include(_ => _.Authorizations)
                .ThenInclude(_ => _.Employee)
                .Single(_ => _.Id == id);
        }
        
        private static void ValidateEntity(ClientEntity entity) {
            EnsureValidEntity(entity);
        }
    }
}