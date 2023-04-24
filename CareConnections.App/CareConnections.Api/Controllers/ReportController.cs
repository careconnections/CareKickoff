using CareConnections.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CareConnections.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository) =>
            _reportRepository = reportRepository;

        [HttpGet]
        public IActionResult GetAllReports() => 
            Ok(_reportRepository.GetAllReports());
    }
}