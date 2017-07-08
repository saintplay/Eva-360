using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eva360.Helpers;

namespace Eva360.Attributes
{
    public class AccessAttribute : ActionFilterAttribute
    {
        public String[] _permisos { get; set; }
        public AccessAttribute(params String[] permisos)
        {
            _permisos = permisos;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var acceso = true;
           
            acceso = filterContext.HttpContext.Session["UsuarioRol"] != null;

            if (!acceso) {
                filterContext.Result = new ViewResult() { ViewName = "_PermisosInsuficientes" };
            }
        }
    }
}