using Dream_voyage.BusinessLogic;
using Dream_voyage.Domain;
using Dream_voyage.Web.Models;
using System.Linq;
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
                    user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                }
                if (user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new DVUser { Username = model.Username, Password = model.Password });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
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