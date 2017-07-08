using System.Web.Mvc;

namespace Eva360.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (Session["UsuarioRol"] == null) {
                return RedirectToAction("Index", "Login");
            }
            else if ((string)Session["UsuarioRol"] == "ADMIN") {
                return RedirectToAction("AdminHome", "Home");
            }
            return View();
        }

        public ActionResult AdminHome()
        {
            return View("Admin");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("Admin");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}