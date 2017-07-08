using System.Linq;
using System.Web.Mvc;
using Eva360.Models.Forms;
using Eva360.Models;
using Eva360.Helpers;

namespace Eva360.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult LoginPost(LoginForm loginModel)
        {
            if (!ModelState.IsValid) {
                TempData["ErrorMessage"] = "Debe completar todos los campos";
                return RedirectToAction("Index");   
            }

            string saltedPassword = PasswordHelper.MD5Hash(loginModel.Password);

            var context = new EVA360Entities();
            var usuario = context.Usuario
                          .FirstOrDefault(u => u.Codigo == loginModel.Usuario &&
                            u.Password == u.Salt + saltedPassword + u.Salt);

            if (usuario != null) {
                Session["UsuarioId"] = usuario.UsuarioId;
                Session["Nombre"] = usuario.Nombre;
                Session["NombreCompleto"] = usuario.Apellido + " " + usuario.Nombre;

                if (usuario.Administrador != null) {
                    Session["UsuarioRol"] = "ADMIN";
                    return RedirectToAction("AdminHome","Home");
                } else if (usuario.Supervisor != null) {
                    Session["UsuarioRol"] = "SUPERVISOR";
                    return RedirectToAction("SupervisorHome", "Home");
                } else if (usuario.Proveedor != null) {
                    Session["UsuarioRol"] = "PROVEEDOR";
                    return RedirectToAction("ProveedorHome", "Home");
                } else if (usuario.Empleado != null) {
                    Session["UsuarioRol"] = "EMPLEADO";
                    return RedirectToAction("EmpleadoHome", "Home");
                }

            }

            TempData["ErrorMessage"] = "Datos Incorrectos";
            return RedirectToAction("Index");
        }

      
    }
}