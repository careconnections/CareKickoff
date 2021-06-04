using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CareKickoff.Services;
using CareKickoff.Models;

namespace CareKickoff.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index(EmployeeModel employee)
        {
            if (employee.IsAuthorized)
            {
                ClientService clientService = new ClientService();
                ViewModel model = new ViewModel();
                model.Client = clientService.GetClientFromId(employee.SelectedClientId);
                model.Careplans = clientService.GetCareplansFromClient(employee.SelectedClientId);

                return View("ClientData", model);
            }
            else
            {
                return View("../Login/LoginFailure", employee);
            }
        }


        
    }


    
}
