using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;

namespace CareKickoff.Infrastructure.Services {
    public class AuthorizationService {
        private readonly IAuthorizationRepository _repository;

        public AuthorizationService(IAuthorizationRepository repository) {
            _repository = repository;
        }

        public void Create(AuthorizationEntity entity) {
            var authorizations = GetByEmployeeId(entity.EmployeeId);

            if (authorizations.All(_ => _.ClientId != entity.ClientId)) {
                _repository.Create(entity);
            }
        }

        public AuthorizationEntity[] GetByClientId(int id) {
            return _repository.GetByClientId(id);
        }
        
        public AuthorizationEntity[] GetByEmployeeId(int id) {
            return _repository.GetByEmployeeId(id);
        }
        
        public void Delete(AuthorizationEntity entity) {
            _repository.Delete(entity);
        }
    }
}