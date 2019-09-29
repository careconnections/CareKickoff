using System;
using System.Linq;
using System.Security.Claims;
using CareKickoff.Domain.Entities;
using CareKickoff.Infrastructure.Factories;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareKickoff.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly EmployeeService _employeeService;
        
        public ClientController(ApplicationDbContext ctx) {
            _employeeService = EmployeeServiceFactory.Create(ctx);
        }
        
        // GET api/client
        [HttpGet]
        [Authorize]
        public ActionResult<ClientEntity[]> Get() {
            var employee = GetCurrentEmployee();

            return employee.Clients.ToArray();
        }

        private EmployeeEntity GetCurrentEmployee() {
            if (!(User.Identity is ClaimsIdentity claimsIdentity)) {
                throw new Exception("No claim could be found.");
            }

            var employeeId = int.Parse(claimsIdentity.Name);
            var employee = _employeeService.GetById(employeeId);
            return employee;
        }
    }
}