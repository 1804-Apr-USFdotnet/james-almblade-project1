using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RRRaves.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var TopRest = new RRRaves.Web.Models.Top3WebRestaurants();
            ViewBag.TopRest = TopRest.Top3List;
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
    }
}