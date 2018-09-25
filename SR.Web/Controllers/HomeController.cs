using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SR.Data;

namespace SR.Web.Controllers
{
    public class HomeController : Controller
    {
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
            DBManager db = new DBManager();
            return View(db.GetAllCategories());
        }

        [HttpGet]
        public ActionResult ChooseCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            DBManager db = new DBManager();
            return View(db.GetAllOffers(offers => offers.CategoriesId == id));
        }

        [HttpGet]
        public ActionResult ResultOfSearch(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            DBManager db = new DBManager();
            return View(db.GetAllCompanies(id));
        }

        [HttpGet]
        public ActionResult ShowExecutors(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new RouteValueDictionary
                    (new { controller = "Home", action = "Error", errorMessage = "Invalid id" }));
            }

            DBManager db = new DBManager();
            return View(db.GetAllExecutors(executors => executors.CompaniesId == id));
        }

        public ActionResult Error(string errorMessage)
        {
            return View((object)errorMessage);
        }
    }
}