using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva360.Controllers
{   
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioRol") == null) {
                return RedirectToAction("Index", "Login");
            }
            else if (HttpContext.Session.GetString("UsuarioRol") == "ADMIN") {
                return RedirectToAction("Index", "Administrador");
            }
            else if (HttpContext.Session.GetString("UsuarioRol") == "EMPLEADO") {
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