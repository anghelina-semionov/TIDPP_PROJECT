using Dream_voyage.BusinessLogic;
using Dream_voyage.Domain;
using Dream_voyage.Web.Models;
using PasswordSecurity;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Dream_voyage.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            using (UserContext db = new UserContext())
            {
                Tour tour = new Tour();
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Шри - Ланка" && u.TourHref == "SriLanka" && u.TourImage == "/images/profile/s8.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Шри - Ланка", TourHref = "SriLanka", TourImage = "/images/profile/s8.jpg" });
                    db.SaveChanges();
                }
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Будапешт, Венгрия" && u.TourHref == "Budapest" && u.TourImage == "/images/profile/b5.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Будапешт, Венгрия", TourHref = "Budapest", TourImage = "/images/profile/b5.jpg" });
                    db.SaveChanges();
                }
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Скопье, Македония" && u.TourHref == "Skopje" && u.TourImage == "/images/profile/b2.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Скопье, Македония", TourHref = "Skopje", TourImage = "/images/profile/b2.jpg" });
                    db.SaveChanges();
                }
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Белград, Сербия" && u.TourHref == "Belgrade" && u.TourImage == "/images/profile/b1.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Белград, Сербия", TourHref = "Belgrade", TourImage = "/images/profile/b1.jpg" });
                    db.SaveChanges();
                }
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Зальцбург, Австрия" && u.TourHref == "Salzburg" && u.TourImage == "/images/profile/salzburgs1.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Зальцбург, Австрия", TourHref = "Salzburg", TourImage = "/images/profile/salzburgs1.jpg" });
                    db.SaveChanges();
                }
                tour = db.Tours.FirstOrDefault(u => u.TourName == "Высокие Татры, Словакия" && u.TourHref == "HighTatras" && u.TourImage == "/images/profile/hightatras3.jpg");
                if (tour == null)
                {
                    db.Tours.Add(new Tour { TourName = "Высокие Татры, Словакия", TourHref = "HighTatras", TourImage = "/images/profile/hightatras3.jpg" });
                    db.SaveChanges();
                }
            }
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
        [Authorize]
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
            string name = HttpContext.User.Identity.Name;
            int id = 0;
            if (name != null)
            {
                id = Int32.Parse(name);
            }

            UserData userData = new UserData();
            UserData user = new UserData();

            userData = user.GetUserData(id);

            if (userData != null)
            {
                return View(userData);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Profile(UserData data, string tourId)
        {
            UserData user = new UserData();
            Tour tour = new Tour();
            UserTour userTour = new UserTour();
            string name = HttpContext.User.Identity.Name;

            int userId = 0;
            if (name != null)
            {
                userId = Int32.Parse(name);
            }

            bool check;

            if (User.Identity.IsAuthenticated)
            {
                using (UserContext db = new UserContext())
                {
                    if (tourId != null)
                    {
                        int id = Int32.Parse(tourId);
                        tour = db.Tours.FirstOrDefault(u => u.TourId == id);
                        userTour.TourId = tour.TourId;
                        userTour.UserId = userId;

                        check = db.UserTours.Any(x => x.TourId == userTour.TourId && x.UserId == userTour.UserId);

                        if (check != true)
                        {
                            db.UserTours.Add(userTour);
                            db.SaveChanges();
                        }
                    }

                    if (data.Username != null)
                    {
                        DVUser users = new DVUser(), _users = new DVUser();
                        users = db.DVUsers.FirstOrDefault(u => u.UserId == userId);
                        _users = db.DVUsers.FirstOrDefault(u => u.UserId == userId);
                        _users.Username = data.Username;
                        db.Entry(users).CurrentValues.SetValues(_users);

                        db.SaveChanges();
                    }
                    if (data.Password != null)
                    {
                        DVUser pass = new DVUser(), _pass = new DVUser();

                        pass = db.DVUsers.FirstOrDefault(u => u.UserId == userId);
                        _pass = db.DVUsers.FirstOrDefault(u => u.UserId == userId);

                        String hash = PasswordStorage.CreateHash(data.Password);
                        _pass.Password = hash;
                        db.Entry(pass).CurrentValues.SetValues(_pass);
                        db.SaveChanges();
                    }
                    if (data.ImageFile != null)
                    {

                        string ImageFileName = Path.GetFileName(data.ImageFile.FileName);
                        string physicalPath = Server.MapPath("~/images/profile/" + ImageFileName);

                        // save image in folder
                        data.ImageFile.SaveAs(physicalPath);

                        DVUserData profiles = new DVUserData(), _profiles = new DVUserData();

                        profiles = db.DVUserDatas.FirstOrDefault(u => u.UserId == userId);
                        _profiles = db.DVUserDatas.FirstOrDefault(u => u.UserId == userId);

                        if (profiles != null && _profiles != null)
                        {
                            _profiles.ImageFile = ImageFileName;
                            db.Entry(profiles).CurrentValues.SetValues(_profiles);
                            db.SaveChanges();
                        }
                        else
                        {
                            DVUserData dV = new DVUserData();
                            dV.UserId = userId;
                            dV.ImageFile = ImageFileName;
                            db.DVUserDatas.Add(dV);
                            db.SaveChanges();
                        }
                    }
                }
                data = user.GetUserData(userId);
                return View(data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Delete(int tourId)
        {
            string name = HttpContext.User.Identity.Name;
            int userId = 0;

            if (name != null)
            {
                userId = Int32.Parse(name);
            }
            UserTour userTour = new UserTour();

            if (User.Identity.IsAuthenticated)
            {
                using (UserContext db = new UserContext())
                {

                    userTour = db.UserTours.FirstOrDefault(u => u.TourId == tourId && u.UserId == userId);
                    db.UserTours.Remove(userTour);
                    db.SaveChanges();
                    return RedirectToAction("Profile", "Home");

                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}