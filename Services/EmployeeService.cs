using CareKickoff.Models;
using CareKickoff.Properties;
using Newtonsoft.Json;

namespace CareKickoff.Data;

public class EmployeeService : IEmployeeService
{
    public Task<Employee[]> GetAllEmployeesAsync()
    {
        var employees = LoadEmployeesJson();
        return Task.FromResult(employees.ToArray());
    }

    public Task<Employee> GetEmployeeByIdAsync(int id)
    {
        var employees = LoadEmployeesJson();
        var employee = employees.Where(i => i.EmployeeId == id).FirstOrDefault();

        return Task.FromResult(employee);
    }

    private List<Employee> LoadEmployeesJson()
    {
        return JsonConvert.DeserializeObject<List<Employee>>(Resources.employees.ToString()); ;
    }
}

