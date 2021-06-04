using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareKickoff.Models;
using CareKickoff.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareKickoff.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(EmployeeModel employeeCheck)
        {
            EmployeeService employeeService = new EmployeeService();
            EmployeeModel employeeData = employeeService.IsValid(employeeCheck);
            if (employeeData != null)
            {
                employeeData.IsAuthorized = true;
                return View("LoginSuccess", employeeData);
            } else
            {
                return View("LoginFailure", employeeCheck);
            }
        }
    }
}
