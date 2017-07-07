using Eva360.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eva360.Models
{
    public static class Permisos
    {
        public static List<String> Administrador = new List<String>() {
            PermisosHelper.PERMISOS.CREAR_ROLES,
            PermisosHelper.PERMISOS.EDITAR_USUARIOS
        };
    }
}