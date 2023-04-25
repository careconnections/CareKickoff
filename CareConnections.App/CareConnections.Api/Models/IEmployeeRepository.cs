using CareConnections.Shared.Domain;

namespace CareConnections.Api.Models
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetAllEmployees();
        Employee GetEmployeeByName(string name);
    }
}