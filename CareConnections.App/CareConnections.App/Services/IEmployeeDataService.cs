using CareConnections.Shared.Domain;

namespace CareConnections.App.Services
{
    public interface IEmployeeDataService
    {
        Task<IList<Employee>?> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByNameAsync(string employeeName);
    }
}