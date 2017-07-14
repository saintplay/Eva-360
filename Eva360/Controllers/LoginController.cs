using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eva360.Models.Forms;

namespace Eva360.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
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

            /*string saltedPassword = PasswordHelper.MD5Hash(loginModel.Password);

            var context = new EVA360Entities();
            var usuario = context.Usuario
                          .FirstOrDefault(u => u.Codigo == loginModel.Usuario &&
                            u.Password == u.Salt + saltedPassword + u.Salt);

            if (usuario != null) {
                HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
                HttpContext.Session.SetString("Nombre", usuario.Nombre);
                HttpContext.Session.SetString("NombreCompleto", usuario.Apellido + " " + usuario.Nombre);

                if (usuario.Administrador != null) {
                    HttpContext.Session.SetString("UsuarioRol", "ADMIN");
                } else if (usuario.Supervisor != null) {
                    HttpContext.Session.SetString("UsuarioRol", "SUPERVISOR");
                } else if (usuario.Proveedor != null) {
                    HttpContext.Session.SetString("UsuarioRol", "PROVEEDOR");
                } else if (usuario.Empleado != null) {
                    HttpContext.Session.SetString("UsuarioRol", "EMPLEADO");
                }

                return RedirectToAction("Index", "Home");
            }*/

            TempData["ErrorMessage"] = "Datos Incorrectos";
            return RedirectToAction("Index");
        }
    }
}