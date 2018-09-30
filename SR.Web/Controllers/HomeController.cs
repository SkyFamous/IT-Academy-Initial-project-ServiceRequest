using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SR.Data;
using SR.Model;
using SR.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SR.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize]
        public ActionResult ServiceRequest()
        {
            return View(unitOfWork.Categories.GetAll());
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChooseCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            return View(unitOfWork.Offers.GetAll(offers => offers.CategoriesId == id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult ResultOfSearch(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }


            return View(unitOfWork.Companies.GetCompaniesByOfferId(id));
        }

        //[HttpGet]
        //public ActionResult ShowExecutors(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Error", new RouteValueDictionary
        //            (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
        //    }

        //    return View(unitOfWork.Executors.GetAll(executors => executors.CompaniesId == id));
        //}

        public ActionResult Error(string errorMessage)
        {
            return View((object)errorMessage);
        }

        [Authorize]
        public ActionResult ShowOffers()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUserId = userManager.FindByEmail(HttpContext.User.Identity.Name).Id;
            var companyId = unitOfWork.Companies.GetAll(c => c.UserId == currentUserId).First().Id;
            var offers = unitOfWork.Offers.GetAll();
            List<OfferViewModel> result = new List<OfferViewModel>();
            foreach (var item in offers)
            {
                result.Add(new OfferViewModel() { Offer = item, IsProviding = unitOfWork.CompOffers.IsProviding(item.Id, companyId) });
            }
            return View(new OffersCollectionViewModel() { OfferViewModels = result, CompanyId = companyId });
        }

        [Authorize]
        [HttpPost]
        public ActionResult ShowOffers(OffersCollectionViewModel model)
        {
            foreach (var item in model.OfferViewModels)
            {
                if (item.IsProviding)
                {
                    if (!unitOfWork.CompOffers.IsProviding(item.Offer.Id, model.CompanyId))
                    {
                        unitOfWork.CompOffers.Create(new CompOffer() { OffersId = item.Offer.Id, CompaniesId = model.CompanyId });
                    }
                }
                else
                {
                    int id;
                    if (unitOfWork.CompOffers.IsProviding(item.Offer.Id, model.CompanyId, out id))
                    {
                        unitOfWork.CompOffers.Delete(id);
                    }
                }
            }
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}