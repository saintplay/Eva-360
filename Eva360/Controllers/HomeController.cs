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
        public ActionResult Index()
        {
            var context = new EVA360Entities();
            var viewModel = new IndexViewModel();
            viewModel.LstUsuario = context.Usuario.ToList();
      
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