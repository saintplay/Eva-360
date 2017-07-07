using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Eva360.Models;
using Eva360.Models.Forms;
using System.Transactions;
using System.Data.Entity.Validation;
using System.Net;

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

            var LstSupervisores = context.Supervisor.Select(x => new
            {
                x.SupervisorId,
                x.Usuario.Nombre,
                x.Usuario.Apellido
            }).ToList();
            var LstProveedores = context.Proveedor.Select(x => new
            {
                x.ProveedorId,
                x.Usuario.Nombre,
                x.Usuario.Apellido
            }).ToList();
            var LstEmpleados = context.Empleado.Select(x => new
            {
                x.EmpleadoId,
                x.Usuario.Nombre,
                x.Usuario.Apellido
            }).ToList();
            var LstPeriodos = context.Periodo.Select(x => new
            {
                x.PeriodoId,
                x.Nombre                
            }).ToList();

            return Json(new
            {
                evaluaciones = LstEvaluaciones,
                supervisores =LstSupervisores,
                proveedores = LstProveedores,
                empleados = LstEmpleados,
                periodos = LstPeriodos
            }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ActualizarEvaluacion(EvaluacionForm evaluacionModel)
        {
            var context = new EVA360Entities();
            Evaluacion evaluacion;

            if (!evaluacionModel.EvaluacionId.HasValue)
            {
                evaluacion = new Evaluacion();
                context.Evaluacion.Add(evaluacion);
            }
            else
            {
                evaluacion = context.Evaluacion
                    .FirstOrDefault(e => e.EvaluacionId == evaluacionModel.EvaluacionId);
            }

            try
            {
                using(var transaction = new TransactionScope())
                {
                    evaluacion.Nombre = evaluacionModel.Nombre;
                    evaluacion.PorcentajeAvance = evaluacionModel.PorcentajeAvance;
                    evaluacion.SupervisorId = evaluacionModel.SupervisorId;
                    evaluacion.EmpleadoId = evaluacionModel.EmpleadoId;
                    evaluacion.PeriodoId = evaluacionModel.PeriodoId;
                    evaluacion.ProveedorId = evaluacionModel.ProveedorId;
                    evaluacion.RutaInforme = evaluacionModel.RutaInforme;

                    context.SaveChanges();
                    transaction.Complete();
                }
            }
            catch(DbEntityValidationException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                List<String> errores = new List<String>();

                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errores.Add(ve.ErrorMessage);
                    }
                }

                return Json(new { errores = errores });
            }

            return getData();
        }
    }
}