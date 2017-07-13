using System.Web.Mvc;
using Eva360.Helpers;

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
                return RedirectToAction("Index", "Administrador");
            }
            else if ((string)Session["UsuarioRol"] == "EMPLEADO") {
                return RedirectToAction("ListarMensajes", "ComunicacionInterna");
            }
            return RedirectToAction("Index", "Login");
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