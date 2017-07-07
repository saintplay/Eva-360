using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eva360.ViewModel.Objetivo;
using Eva360.Models;
using System.Transactions;
using System.Net;
using System.Data.Entity.Validation;

namespace Eva360.Controllers
{
    public class ObjetivoController : Controller
    {
        [NonAction]
        public JsonResult getData()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstObjetivos = context.Objetivo.ToList();
            var LstPeriodos = context.Periodo.Select(x => new
            {
                x.PeriodoId,
                x.Nombre
            }).ToList();

            return Json(new
            {
                objetivos = LstObjetivos,
                periodos = LstPeriodos
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarObjetivos()
        {
            return getData();
        }

        [HttpPost]
        public ActionResult ActualizarObjetivo(ObjetivoForm objetivoModel)
        {
            var context = new EVA360Entities();
            Objetivo objetivo;

            if (!objetivoModel.ObjetivoId.HasValue) {
                objetivo = new Objetivo();
                objetivo.FechaCreacion = DateTime.Now;
                objetivo.UsuarioCreacionId = 1;//TO DO
                context.Objetivo.Add(objetivo);
            }
            else {
                objetivo = context.Objetivo
                           .FirstOrDefault(o => o.ObjetivoId == objetivoModel.ObjetivoId);
            }

            try {
                using (var transaction = new TransactionScope())
                {
                    objetivo.Nombre = objetivoModel.Nombre;
                    objetivo.Orden = objetivoModel.Orden;
                    objetivo.PeriodoId = objetivoModel.PeriodoId;
                    objetivo.Descripcion = objetivoModel.Descripcion;

                    context.SaveChanges();
                    transaction.Complete();
                }
            }
            catch(DbEntityValidationException e) {
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