using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eva360.Helpers;

namespace Eva360.Filters
{
    public class AccesAttribute : ActionFilterAttribute
    {
        public String[] _permiso { get; set; }
        public AccesAttribute(params String[] permiso)
        {
            _permiso = permiso;
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