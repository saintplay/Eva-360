using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eva360.ViewModel.Login;
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
                    Session["AdministradorId"] = usuario.Administrador.AdministradorId;
                    Session["UsuarioRol"] = "ADMIN";
                } else if (usuario.Supervisor != null) {
                    Session["SupervisorId"] = usuario.Supervisor.SupervisorId;
                    Session["UsuarioRol"] = "SUPERVISOR";
                } else if (usuario.Proveedor != null) {
                    Session["ProveedorId"] = usuario.Proveedor.ProveedorId;
                    Session["UsuarioRol"] = "PROVEEDOR";
                } else if (usuario.Empleado != null) {
                    Session["EmpleadoId"] = usuario.Empleado.EmpleadoId;
                    Session["UsuarioRol"] = "EMPLEADO";
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