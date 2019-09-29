using System.Collections.Generic;
using CareKickoff.Domain.Entities;

namespace CareKickoff.Infrastructure.Builders {
    public class EmployeeEntityBuilder {
        private readonly EmployeeEntity _employeeEntity;

        public EmployeeEntityBuilder() {
            _employeeEntity = new EmployeeEntity();
        }

        public EmployeeEntityBuilder WithName(string name) {
            _employeeEntity.Name = name;
            return this;
        }

        public EmployeeEntityBuilder WithClients(IEnumerable<ClientEntity> clients) {
            _employeeEntity.Clients = clients;
            return this;
        }

        public EmployeeEntity ToEntity() {
            return _employeeEntity;
        }
    }
}