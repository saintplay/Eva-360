using Eva360.Models;
using Eva360.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eva360.Controllers
{
    public class HomeController : BaseController
    {
        public class CustomUser {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }

            public CustomUser(string Nombre, string Apellido, string Email) {
                this.Nombre = Nombre;
                this.Apellido= Apellido;
                this.Email = Email;
            }
        }

        public ActionResult Index()
        {
            var context = new EVA360Entities();
            var viewModel = new IndexViewModel();
            viewModel.LstUsuario = context.Usuario.AsEnumerable().Select(x => new CustomUser(
                    x.Nombre,
                    x.Apellido,
                    x.Email
                )
            ).ToList();
      
            return View(viewModel);
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