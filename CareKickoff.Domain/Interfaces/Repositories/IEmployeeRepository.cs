using CareKickoff.Domain.Entities;

namespace CareKickoff.Domain.Interfaces.Repositories {
    public interface IEmployeeRepository {
        void Create(EmployeeEntity entity);
        void Delete(EmployeeEntity entity);
        EmployeeEntity GetById(int id);
        EmployeeEntity[] GetAll();
    }
}