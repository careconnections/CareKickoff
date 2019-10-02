using System;
using System.Collections.Generic;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Enums;

namespace CareKickoff.Infrastructure.Builders {
    public class ClientEntityBuilder {
        private readonly ClientEntity _clientEntity;

        public ClientEntityBuilder() {
            _clientEntity = new ClientEntity();
        }

        public ClientEntityBuilder WithFirstName(string firstname) {
            _clientEntity.FirstName = firstname;
            return this;
        }

        public ClientEntityBuilder WithLastName(string lastname) {
            _clientEntity.LastName = lastname;
            return this;
        }
        
        public ClientEntityBuilder WithBirthDate(DateTime birthDate) {
            _clientEntity.BirthDate = birthDate;
            return this;
        }
        
        public ClientEntityBuilder WithGender(GenderType gender) {
            _clientEntity.Gender = gender;
            return this;
        }
        
        public ClientEntityBuilder WithEmployees(IEnumerable<EmployeeEntity> employees) {
            _clientEntity.Employees = employees;
            return this;
        }
        
        public ClientEntity ToEntity() {
            return _clientEntity;
        }
    }
}