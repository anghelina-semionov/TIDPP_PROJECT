using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream_voyage.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AuthIndex", "Home");
            }
                return View();
        }

        public ActionResult AuthIndex()
        {
                return View();
        }

        public ActionResult Salzburg()
        {
            return View();
        }

        public ActionResult Belgrade()
        {
            return View();
        }

        public ActionResult Budapest()
        {
            return View();
        }

        public ActionResult HighTatras()
        {
            return View();
        }

        public ActionResult Skopje()
        {
            return View();
        }

        public ActionResult SriLanka()
        {
            return View();
        }

        public ActionResult FAQs()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Result(string tourId)
        {
            if(tourId != null)
            {
                return RedirectToAction("Profile", "Home", new { @id = tourId });
            }
            return View();
        }
        [Authorize]
        public ActionResult Profile()
        {
            var tourId = Request.QueryString["id"];
            
            return View(tourId);
        }  
        //[HttpPost]
        //[Authorize]
        //public ActionResult Profile(string tourId)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (tourId != null)
        //        {

        //            return View(tourId);
        //        }
        //        else return View(1);
        //    }

        //    return RedirectToAction("Index", "Login");
        //}
    }
}