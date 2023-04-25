using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext) => 
            _appDbContext = appDbContext;

        public IList<Employee> GetAllEmployees() =>
            _appDbContext.Employees.ToList();

        public Employee GetEmployeeByName(string name) =>
            _appDbContext.Employees.FirstOrDefault(e => e.Name == name);
    }
}