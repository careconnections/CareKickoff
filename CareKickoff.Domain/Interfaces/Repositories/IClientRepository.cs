using CareKickoff.Domain.Entities;

namespace CareKickoff.Domain.Interfaces.Repositories {
    public interface IClientRepository {
        void Create(ClientEntity entity);
        void Delete(ClientEntity entity);
        ClientEntity GetById(int id);
        ClientEntity[] GetAll();
    }
}