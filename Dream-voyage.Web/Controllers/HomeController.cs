using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dream_voyage.Web.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            String res = "Нет";
            if (User.Identity.IsAuthenticated)
            {
                res = "Вы - " + User.Identity.Name;
            }
            return res;
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
        [Authorize]
        public ActionResult Profile()
        {
            return View();
        }
    }
}