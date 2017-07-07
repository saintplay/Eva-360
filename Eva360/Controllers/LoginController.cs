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
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            var viewModel = new LoginForm();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginForm loginModel)
        {
            if (!ModelState.IsValid) {
                PostMessage(MessageType.Warning, "Debe completar todos los campos");
                return View(loginModel);    
            }

            var context = new EVA360Entities();
            var usuario = context.Usuario
                          .FirstOrDefault(u => u.Codigo == loginModel.Usuario &&
                            u.Password == u.Salt + (PasswordHelper.MD5Hash(loginModel.Password) + u.Salt));

            if (usuario != null) {
                //Login exitoso
                PostMessage(MessageType.Success, "Bienvenido" + usuario.Nombre);

                 if(usuario.Administrador != null) {
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

                Session["UsuarioId"] = usuario.UsuarioId;
                Session["Nombre"] = usuario.Nombre;
                Session["NombreCompleto"] = usuario.Apellido + usuario.Nombre;
            }
            else {
                PostMessage(MessageType.Error, "Usuario/Contraseña incorrectos");
            }

            return View(loginModel);
        }

      
    }
}