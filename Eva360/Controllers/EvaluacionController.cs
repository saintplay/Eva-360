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

        
    }
}