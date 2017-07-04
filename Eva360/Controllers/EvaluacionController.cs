using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eva360.Models;

namespace Eva360.Controllers
{
    public class EvaluacionController : Controller
    {
        [NonAction]
        public JsonResult getData()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstEvaluaciones = context.Evaluacion.ToList();

            return Json(new { evaluaciones = LstEvaluaciones }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarEvaluaciones()
        {
            return getData();
        }
    }
}