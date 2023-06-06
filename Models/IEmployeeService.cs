namespace CareKickoff.Models
{
    public interface IEmployeeService
    {
        public Task<Employee[]> GetAllEmployeesAsync();

        public Task<Employee> GetEmployeeByIdAsync(int id);
        
    }
}
