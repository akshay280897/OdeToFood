using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        OdeToFoodDb db = new OdeToFoodDb();
        public ActionResult Index([Bind(Prefix ="id")]int restaurantId)
        {
            var restaurant = db.Restaurant.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();
        
        }

        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reviews review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index",new { id = review.RestaurantId});
            }
            return View(review);
        }

        public ActionResult Edit(int id)
        {
            Reviews E_review = db.Reviews.Find(id);
            return View(E_review);
        }

     

        [HttpPost]
        public ActionResult Edit(Reviews review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { id = review.RestaurantId});
            }
            return View(review);
        }

        public ActionResult Delete(int id)
        {
            Reviews D_review = db.Reviews.Find(id);
            return View(D_review);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviews review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = review.RestaurantId });
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
