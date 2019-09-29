using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;

namespace CareKickoff.Infrastructure.Services {
    public class ClientService {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository) {
            _repository = repository;
        }
        
        public void Create(ClientEntity entity) {
            _repository.Create(entity);
        }

        public void Delete(ClientEntity entity) {
            _repository.Delete(entity);
        }

        public ClientEntity GetById(int id) {
            return _repository.GetById(id);
        }

        public ClientEntity[] GetAll() {
            return _repository.GetAll();
        }
    }
}