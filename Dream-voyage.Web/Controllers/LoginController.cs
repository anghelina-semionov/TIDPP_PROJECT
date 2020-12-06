using Dream_voyage.BusinessLogic;
using Dream_voyage.Domain;
using Dream_voyage.Web.Models;
using PasswordSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Dream_voyage.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                DVUser user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.DVUsers.FirstOrDefault(u => u.Username == model.Username);
                    
                }
                if (user != null)
                {
                    bool res = PasswordStorage.VerifyPassword(model.Password, user.Password);
                    if (res == true)
                    {
                        model.UserId = user.UserId;
                        FormsAuthentication.SetAuthCookie(model.UserId.ToString(), true);
                        return RedirectToAction("Profile", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Неверный пароль!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Пользователя с таким логином и паролем нет.");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}