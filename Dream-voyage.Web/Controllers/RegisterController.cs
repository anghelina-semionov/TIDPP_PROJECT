using Dream_voyage.BusinessLogic;
using Dream_voyage.Domain;
using Dream_voyage.Web.Models;
using PasswordSecurity;
using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Dream_voyage.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index (UserRegister model)
        {

            if (ModelState.IsValid)
            {
                DVUser user = null;
                using (UserContext db = new UserContext())
                {
                    String hash = PasswordStorage.CreateHash(model.Password);
                    user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == hash);
                }
                if (user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        String hash = PasswordStorage.CreateHash(model.Password);
                        db.Users.Add(new DVUser { Username = model.Username, Password = hash });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Username == model.Username && u.Password == hash).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, true);
                        return RedirectToAction("Profile", "Home", user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка!");
                }
            }
            return View(model);
        }
    }
}