using CareKickoff.Domain.Entities;

namespace CareKickoff.Infrastructure.Builders {
    public class AuthorizationEntityBuilder {
        private readonly AuthorizationEntity _authorizationEntity;

        public AuthorizationEntityBuilder() {
            _authorizationEntity = new AuthorizationEntity();
        }
        
        public AuthorizationEntityBuilder WithClientId(int id) {
            _authorizationEntity.ClientId = id;
            return this;
        }
        
        public AuthorizationEntityBuilder WithEmployeeId(int id) {
            _authorizationEntity.EmployeeId = id;
            return this;
        }
        
        public AuthorizationEntity ToEntity() {
            return _authorizationEntity;
        }
    }
}