using System.Linq;
using CareKickoff.Domain.Entities;
using CareKickoff.Domain.Interfaces.Repositories;
using CareKickoff.Persistence.Records;
using Microsoft.EntityFrameworkCore;

namespace CareKickoff.Persistence.Repositories {
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository {
        public EmployeeRepository(ApplicationDbContext ctx) : base(ctx) { }
        
        public void Create(EmployeeEntity entity) {
            ValidateEntity(entity);
            
            DataContext.Add(EmployeeRecord.FromEntity(entity));
            DataContext.SaveChanges();
        }
        
        public void Delete(EmployeeEntity entity) {
            var record = GetEmployeeById(entity.Id);
            DataContext.Employees.Remove(record);
            DataContext.SaveChanges();
        }

        public EmployeeEntity GetById(int id) {
            return GetEmployeeById(id).ToEntity();
        }

        public EmployeeEntity[] GetAll() {
            var employees = DataContext.Employees
                .OrderBy(_ => _.Id)
                .Include(_ => _.Authorizations)
                .ThenInclude(_ => _.Client)
                .Select(_ => _.ToEntity())
                .ToArray();

            return employees;
        }
        
        private EmployeeRecord GetEmployeeById(int id) {
            return DataContext.Employees
                .Include(_ => _.Authorizations)
                .ThenInclude(_ => _.Client)
                .Single(_ => _.Id == id);
        }
        
        private static void ValidateEntity(EmployeeEntity entity) {
            EnsureValidEntity(entity);
        }
    }
}