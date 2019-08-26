using CareConnection.Core.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CareConnection.Core
{
    public class EmployeeProvider
    {
        List<Employee> _employeeList;
        private EmployeeProvider()
        {
            GetEmployees();
        }

        private static EmployeeProvider instance = null;
        public static EmployeeProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeProvider();
                }
                return instance;
            }
        }

        #region private methods
        private void GetEmployees()
        {
            string employeeFileName = "DataFiles.employees.json";

            var assembly = typeof(EmployeeProvider).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{employeeFileName}");

            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                _employeeList = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
        }
        #endregion

        #region public methods
        public Employee GetEmployeeByID(int empLoyeeID)
        {
            Employee employee = null;
            foreach (var emp in _employeeList)
            {
                if (empLoyeeID.Equals(emp.EmployeeID))
                {
                    employee = emp;
                    break;
                }
            }
            return employee;
        }
        #endregion
    }
}