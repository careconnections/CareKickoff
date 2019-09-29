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
    public class CareplanController : ControllerBase {
        private readonly ClientService _clientService;
        private readonly EmployeeService _employeeService;
        
        public CareplanController(ApplicationDbContext ctx) {
            _clientService = ClientServiceFactory.Create(ctx);
            _employeeService = EmployeeServiceFactory.Create(ctx);
        }
        
        // GET api/careplan/{id}
        [HttpGet]
        [Authorize]
        public ActionResult<CareplanEntity[]> Get(int id) {
            var employee = GetCurrentEmployee();

            if (employee.Clients.All(_ => _.Id != id)) {
                throw new Exception($"This employee {employee.Name} has no authorization to access client {id}.");
            }

            var client = _clientService.GetById(id);
            
            return client.Careplans.ToArray();
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