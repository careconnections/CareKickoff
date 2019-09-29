using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;

namespace CareKickoff.Infrastructure.Services {
    public class EmployeeService {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository) {
            _repository = repository;
        }
        
        public void Create(EmployeeEntity entity) {
            _repository.Create(entity);
        }

        public void Delete(EmployeeEntity entity) {
            _repository.Delete(entity);
        }
        
        public EmployeeEntity GetById(int id) {
            return _repository.GetById(id);
        }
        
        public EmployeeEntity[] GetAll() {
            return _repository.GetAll();
        }
    }
}