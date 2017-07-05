using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Transactions;
using Eva360.Models;
using System.Net;
using Eva360.ViewModel.Periodos;

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

        [HttpPost]
        public ActionResult ActualizarPeriodo(PeriodoForm periodomodel)
        {
            var context = new EVA360Entities();
            Periodo periodo;

            if (periodomodel.PeriodoId.HasValue == false) { // Crear nuevo
                periodo = new Periodo();
                context.Periodo.Add(periodo);
            }
            else { // Editar exsistente
                periodo = context.Periodo
                    .FirstOrDefault(p => p.PeriodoId == periodomodel.PeriodoId);
            }

            try {
                using(var Transaction = new TransactionScope()) {
                    periodo.Nombre = periodomodel.Nombre;
                    periodo.Estado = periodomodel.Estado;
                    periodo.FechaInicio = periodomodel.FechaInicio;
                    periodo.FechaFin = periodomodel.FechaFin;

                    context.SaveChanges();
                    Transaction.Complete();
                }
            }
            catch (DbEntityValidationException e) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                List<String> errores = new List<String>();

                foreach (var eve in e.EntityValidationErrors) {
                    foreach (var ve in eve.ValidationErrors) {
                        errores.Add(ve.ErrorMessage);
                    }
                }

                return Json(new { errores = errores });
            }

            return getData();
        }

    }
}