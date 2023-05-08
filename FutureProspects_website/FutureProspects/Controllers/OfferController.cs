using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Linq;

namespace FutureProspects.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _db;
        public  OfferController(ApplicationDbContext db) => _db = db;//przekzanie połączenia
        [HttpGet ]
        public IActionResult Index(IEnumerable<Offer>? list)
        {
            IEnumerable<Offer> objOfferList = _db.Offers.ToList();
            var SearchOfferData = list;

            if (SearchOfferData==null)
            {
              
                return View(SearchOfferData);

            }
            var OfferData = _db.Empolyers.Include(e => e.Offer);

            return View(OfferData);
        }
        [HttpPost("Index")]

        public IActionResult IndexPost(searchRequest request)
        {

            var empolyerData = _db.Empolyers.Include(e => e.Offer.Where(o => o.OfferTitle.Contains(request.searchedText)));
            return View("Index", empolyerData);

       


        }
        public IActionResult jobOffer(int? id)
        {
            var objOffer = _db.Offers.Find(id);
            var objEmpolyer = _db.Empolyers.Find(objOffer?.EmpolyerId);
            /*var OfferDataa = _db.Empolyers.Include(e=>objOfferList);*/
            var model = new JobOfferModel
            {
                Offer = objOffer,
                Empolyer = objEmpolyer
            };

            return View(model);
        }
        [HttpPost("jobOffer")]
        public async Task<IActionResult> Applay(int? id )
        {
            var userName=User.FindFirst(ClaimTypes.Name).Value;

           var userId = _db.Employees.First(u=>u.Email==userName).Id;
            if (_db.EmployeeOffers.Find(id,userId)!=null) {
                return RedirectToAction("Index", "Offer");


            }
            else
            {
                var employeeOffer = new EmployeeOffer
                {
                    EmployeeId = userId,
                    OfferId = id.Value
                };
                _db.EmployeeOffers.Add(employeeOffer);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Offer");
        }
    }
}
