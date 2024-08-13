using Microsoft.AspNetCore.Mvc;

namespace PolyDo.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
