using CareConnections.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareConnections.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) =>
            _employeeRepository = employeeRepository;

        [HttpGet]
        public IActionResult GetAllEmployees() => 
            Ok(_employeeRepository.GetAllEmployees());

        [HttpGet("{name}")]
        public IActionResult GetEmployeeByName(string name) =>
            Ok(_employeeRepository.GetEmployeeByName(name));
    }
}