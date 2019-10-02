using Microsoft.AspNetCore.Mvc;

namespace CareKickoff.Api.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return Redirect("/swagger");
        }
    }
}