using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Linq;

namespace FutureProspects.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _db;
        public  OfferController(ApplicationDbContext db) => _db = db;//przekzanie połączenia
        public IActionResult Index()
        {
            IEnumerable<Offer> objOfferList = _db.Offers.ToList();
            var OfferData  = _db.Empolyers.Include(e=> e.Offer);

            return View(OfferData);
        }
        public IActionResult jobOffer(int? id)
        {
            var objOffer = _db.Offers.Find(id);
            var objEmpolyer = _db.Empolyers.Find(objOffer.EmpolyerId);
            /*var OfferDataa = _db.Empolyers.Include(e=>objOfferList);*/
            var model = new JobOfferModel
            {
                Offer = objOffer,
                Empolyer = objEmpolyer
            };

            return View(model);
        }
    }
}
