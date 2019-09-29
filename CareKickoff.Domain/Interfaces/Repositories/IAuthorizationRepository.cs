using CareKickoff.Domain.Entities;

namespace CareKickoff.Domain.Interfaces.Repositories {
    public interface IAuthorizationRepository {
        void Create(AuthorizationEntity entity);
        void Delete(AuthorizationEntity entity);
        AuthorizationEntity[] GetByEmployeeId(int id);
        AuthorizationEntity[] GetByClientId(int id);
        AuthorizationEntity[] GetAll();
    }
}