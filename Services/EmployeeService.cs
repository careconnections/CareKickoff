using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CareKickoff.Models;
using Newtonsoft.Json;

namespace CareKickoff.Services
{     
    public class EmployeeService
    {
        private EmployeeModel[] employees;

        public EmployeeService()
        {
            string path = @"e:\Projects\CareKickoff\Data\employees.json";
            employees = JsonConvert.DeserializeObject<EmployeeModel[]>(File.ReadAllText(path));
        }

        public EmployeeModel IsValid(EmployeeModel employee)
        {
            return employees.FirstOrDefault(x => x.Name == employee.Name && x.Password == employee.Password);
        }
    }
}
