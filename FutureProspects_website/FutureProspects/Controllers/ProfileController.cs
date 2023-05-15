using Microsoft.AspNetCore.Mvc;

namespace FutureProspects.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProfileController(ApplicationDbContext db) => _db = db;
        public IActionResult Index()
        {
            var userName = User.FindFirst(ClaimTypes.Name).Value;

            var user = _db.Employees.First(u => u.Email == userName);
            return View(user);
        }
    }
}
