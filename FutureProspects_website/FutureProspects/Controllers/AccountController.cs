using Microsoft.AspNetCore.Mvc;

namespace FutureProspects.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult registerEmployee()
        {
            return View();
        }
        public IActionResult registerEmployer()
        {
            return View();
        }
    }
}
