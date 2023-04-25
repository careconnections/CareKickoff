using CareConnections.Api.Models;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CareConnections.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository) =>
            _reportRepository = reportRepository;

        [HttpGet]
        public IActionResult GetAllReports() => 
            Ok(_reportRepository.GetAllReports());

        [HttpGet("{id}")]
        public IActionResult GetReportById(int id) =>
            Ok(_reportRepository.GetReportById(id));

        [HttpPost]
        public IActionResult CreateReport([FromBody] Report report)
        {
            if (report == null)
                return BadRequest();

            var createdReport = _reportRepository.AddReport(report);

            return Created("report", createdReport);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReport(int id)
        {
            if (id == 0)
                return BadRequest();

            var reportToDelete = _reportRepository.GetReportById(id);
            if (reportToDelete == null)
                return NotFound();

            _reportRepository.DeleteReport(id);

            return NoContent();
        }
    }
}