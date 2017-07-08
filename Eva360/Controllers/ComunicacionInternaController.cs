using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Net;
using Eva360.Models;
using Eva360.Models.Forms;
using System.Transactions;
using Eva360.ViewModels.ComunicacionesInternas;

namespace Eva360.Controllers
{
    public class ComunicacionInternaController : BaseController
    {
        [NonAction]
        public JsonResult getData()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstCInterna = context.ComunicacionInterna.ToList();


            return Json(new
            {
                comunicaciones = LstCInterna
            }, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult ListarMensajes()
        {
            var context = new EVA360Entities();
            var viewModel = new ListarMensajesViewModel();
            viewModel.LstCom = context.ComunicacionInterna
                                      .OrderByDescending(c=>c.FechaCreacion).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CrearComunicacion(ComunicacionInternaForm comunicacionModel)
        {
            var context = new EVA360Entities();
            ComunicacionInterna comunicacion;
            comunicacion = new ComunicacionInterna();

            context.ComunicacionInterna.Add(comunicacion);

            try {
                using(var transaction = new TransactionScope())
                {
                    comunicacion.EmpleadoId = comunicacionModel.EmpleadoId;
                    comunicacion.Contenido = comunicacionModel.Contenido;
                    comunicacion.FechaCreacion = DateTime.Now;
                    comunicacion.UsuarioCreacionId = comunicacion.EmpleadoId;

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