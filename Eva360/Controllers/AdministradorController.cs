using System.Web.Mvc;
using Eva360.Helpers;
using Eva360.Attributes;

namespace Eva360.Controllers
{
    public class AdministradorController : BaseController
    {
        [Access(PermisosHelper.PERMISOS.LISTAR_USUARIOS)]
        public ActionResult Index()
        {
            return View("Admin");
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