using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult search(string name)
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
    }
}