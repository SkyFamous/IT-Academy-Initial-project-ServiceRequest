using BAL.Models;
using BAL.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private ICompanyRepository _companyRepository;
        private IOfferRepository _offerRepository;
        private ICompOfferRepository _compOfferRepository;

        public HomeController()
        {

        }

        [Inject]
        public HomeController(ICategoryRepository categoryRepository, ICompanyRepository companyRepository, IOfferRepository offerRepository, ICompOfferRepository compOfferRepository)
        {
            _categoryRepository = categoryRepository;
            _companyRepository = companyRepository;
            _offerRepository = offerRepository;
            _compOfferRepository = compOfferRepository;
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

        [Authorize(Roles = "customer")]
        public ActionResult ServiceRequest()
        {
            return View(_categoryRepository.GetAll());
        }

        [Authorize(Roles = "customer")]
        [HttpGet]
        public ActionResult ChooseCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            return View(_offerRepository.GetAll(offers => offers.CategoriesId == id));
        }

        [Authorize(Roles = "customer")]
        [HttpGet]
        public ActionResult ResultOfSearch(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }


            return View(_companyRepository.GetCompaniesByOfferId(id));
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

        [Authorize(Roles = "company_agent")]
        public ActionResult ShowOffers()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUserId = userManager.FindByEmail(HttpContext.User.Identity.Name).Id;
            var companyId = _companyRepository.GetAll(c => c.UserId == currentUserId).First().Id;
            var offers = _offerRepository.GetAll();
            List<OfferViewModel> result = new List<OfferViewModel>();
            foreach (var item in offers)
            {
                result.Add(new OfferViewModel() { Offer = item, IsProviding = _compOfferRepository.IsProviding(item.Id, companyId) });
            }
            return View(new OffersCollectionViewModel() { OfferViewModels = result, CompanyId = companyId });
        }

        [Authorize(Roles = "company_agent")]
        [HttpPost]
        public ActionResult ShowOffers(OffersCollectionViewModel model)
        {
            foreach (var item in model.OfferViewModels)
            {
                if (item.IsProviding)
                {
                    if (!_compOfferRepository.IsProviding(item.Offer.Id, model.CompanyId))
                    {
                        _compOfferRepository.Create(new CompOffer() { OffersId = item.Offer.Id, CompaniesId = model.CompanyId });
                    }
                }
                else
                {
                    CompOffer id;
                    if (_compOfferRepository.IsProviding(item.Offer.Id, model.CompanyId, out id))
                    {
                        _compOfferRepository.Delete(id);
                    }
                }
            }
            _categoryRepository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}