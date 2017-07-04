using System.Linq;
using Eva360.Models;
using System.Web.Mvc;
using Eva360.ViewModel.User;
using System.Transactions;
using System;
using System.Net;
using System.Data.Entity.Validation;
using System.Collections.Generic;

namespace Eva360.Controllers
{
    public class UsuarioController : BaseController
    {
        [NonAction]
        public JsonResult getData()
        {
            var context = new EVA360Entities();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;

            var LstUsuarios = context.Usuario.ToList();
            var LstTipoDocumentos = context.TipoDocumento.Select(x => new {
                x.TipoDocumentoId,
                x.Sigla
            }).ToList();

            return Json(new { usuarios = LstUsuarios, tipodocumentos = LstTipoDocumentos }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListarUsuario()
        {
            return getData();
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(
            int? UsuarioId,
            string Nombre,
            string Apellido,
            string Codigo,
            string Email,
            string FechaNacimiento,
            string Sexo,
            int? TipoDocumentoId,
            string NroDocumento
        )
        {
            var context = new EVA360Entities();
            Usuario usuario;

            if (UsuarioId.HasValue == false) { // Crear nuevo
                usuario = new Usuario();
                usuario.Estado = UsuarioEstado.Activo;
                context.Usuario.Add(usuario);
            }
            else { // Editar exsistente
                usuario = context.Usuario
                    .FirstOrDefault(u => u.UsuarioId == UsuarioId);
            }

            try {
                using (var Transaction = new TransactionScope()) {
                    usuario.Nombre = Nombre;
                    usuario.Apellido = Apellido;
                    usuario.Codigo = Codigo;
                    usuario.Email = Email;
                    usuario.FechaNacimiento = DateTime.Parse(FechaNacimiento);
                    usuario.Sexo = Sexo;
                    usuario.TipoDocumentoId = (int)TipoDocumentoId;
                    usuario.NroDocumento = NroDocumento;

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