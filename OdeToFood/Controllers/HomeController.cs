using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
  
    public class HomeController : Controller
    {
        OdeToFoodDb db = new OdeToFoodDb();

        public ActionResult Autocomplete(string term) {
            var model =
                        db.Restaurant
                        .Where(r => r.Name.StartsWith(term))
                        .Take(10)
                        .Select(r => new
                        {
                            label = r.Name
                        });
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index(string searchTerm = null)
        {

            var model =
                    db.Restaurant
                    .Where(r=>searchTerm==null || r.Name.StartsWith(searchTerm))
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Select(r => new RestaurantListView
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountofReviews = r.Reviews.Count()
                    }
                    );
            if (Request.IsAjaxRequest())
            {
                return PartialView("_SearchRestaurant", model);
            }
            return View(model);


        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Akshay Potdar";
            model.Location = "Pune";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}