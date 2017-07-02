using System.Linq;
using Eva360.Models;
using System.Web.Mvc;

namespace Eva360.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult ListarUsuario()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstUsuarios = context.Usuario.ToList();
            return Json(new { success = true, usuarios = LstUsuarios }, JsonRequestBehavior.AllowGet);
        }
    }
}