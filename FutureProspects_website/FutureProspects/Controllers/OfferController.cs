using Microsoft.AspNetCore.Mvc;

namespace FutureProspects.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _db;
        public  OfferController(ApplicationDbContext db) => _db = db;//przekzanie połączenia
        public IActionResult Index()
        {
            var OfferData  = _db.Empolyers.Include(e=>e.Offer);
            //IEnumerable<Offer> objOfferList = _db.Offers;
        
            return View(OfferData);
        }
    }
}
