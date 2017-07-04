using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Transactions;
using Eva360.Models;
using System.Net;


namespace Eva360.Controllers
{
    public class PeriodoController : Controller
    {
        [NonAction]
        public JsonResult getData()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstPeriodos = context.Periodo.ToList();

            return Json(new { periodos = LstPeriodos, }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarPeriodos()
        {
            return getData();
        }

        //[HttpPost]
        //public ActionResult ActualizarPeriodo(
        //    int? PeriodoId,
        //    DateTime FechaInicio,
        //    DateTime FechaFin,
        //    string Nombre,
        //    string Estado
        //    )
        //{
        //    var context = new EVA360Entities();
        //    Periodo periodo;

        //    if (PeriodoId.HasValue)
        //    {
        //        periodo = new Periodo();
        //        periodo.Estado = PeriodoEstado.Activo;
        //        context.Periodo.Add(periodo);
        //    }
        //    else
        //    {
        //        periodo = context.Periodo
        //                         .FirstOrDefault(p => p.PeriodoId == PeriodoId);
        //    }

        //    try
        //    {
        //        using(var transactin = new TransactionScope())
        //        {
        //            periodo.FechaInicio = FechaInicio;

        //            periodo.Nombre = Nombre;

        //        }
        //    }
        //}

    }
}