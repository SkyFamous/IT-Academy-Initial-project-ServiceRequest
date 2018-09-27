using SR.Data;
using System.Web.Mvc;
using System.Web.Routing;
using SR.Data.Repositories;
using System.Collections.Generic;

namespace SR.Web.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;

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

        public ActionResult ServiceRequest()
        {
            return View(unitOfWork.Categories.GetAll());
        }

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

        [HttpGet]
        public ActionResult ResultOfSearch(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }
            return View(unitOfWork.Companies.GetAll(companies => companies.Id == id));
        }

        [HttpGet]
        public ActionResult ShowExecutors(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            return View(unitOfWork.Executors.GetAll(executors => executors.CompaniesId == id));
        }

        public ActionResult Error(string errorMessage)
        {
            return View((object)errorMessage);
        }
    }
}