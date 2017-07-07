using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eva360.Helpers
{
    public static class PermisosHelper
    {
        public static bool TienePermiso(this HttpSessionStateBase session, params String[] permiso)
        {
            if (permiso.Length == 0) return true;

            return false;
        }

        public static class PERMISOS
        {
            //Admin
            public const String CREAR_ROLES = "PERMISO.CREAR_ROLES";
            public const String LISTAR_ROLES = "PERMISO.LISTAR_ROLES";
            public const String EDITAR_USUARIOS = "PERMISO.EDITAR_USUARIOS";
            public const String LISTAR_USUARIOS = "PERMISO.LISTAR_USUARIOS";
            public const String ELIMINAR_USUARIOS = "PERMISO.ELIMINAR_USUARIOS";//CAMBIA ESTADO A INACTIVO
            public const String VER_RENDIMIENTO = "PERMISO.VER_RENDIMIENTO";

            //Empleado
            public const String VER_OBJETIVOS = "PERMISO.VER_OBJETIVOS";
            public const String VER_PUNTAJE = "PERMISO.VER_PUNTAJE";//<---REVISAR
            public const String VER_COMUNICACION_INTERNA = "PERMISO.VER_COMUNICACION_INTERNA";
            public const String CREAR_COMUNICACION_INTERNA = "PERMISO.CREAR_COMUNICACION_INTERNA";

            //Supervisor
            public const String REGISTRAR_PUNTAJE = "PERMISO.REGISTRAR_PUNTAJE";//<---REGISTRAR_EVALUACION??
            public const String EDITAR_PUNTAJE = "PERMISO.EDITAR_PUNTAJE";//<---EDITAR_EVALUACION??
            public const String LISTAR_PUNTAJE = "PERMISO.LISTAR_PUNTAJE";//<---LISTAR_EVALUACION??
            public const String LISTAR_EVALUACION360 = "PERMISO.LISTAR_EVALUACION360";//<---VER DETALLE DE LA EV360 DE 1 EMPLEADO
            public const String REGISTRAR_EMPLEADOS = "PERMISO.REGISTRAR_EMPLEADOS";
            public const String EDITAR_EMPLEADOS = "PERMISO.EDITAR_EMPLEADOS";
            public const String LISTAR_EMPLEADOS = "PERMISO.LISTAR_EMPLEADOS";
            public const String ELIMINAR_EMPLEADOS = "PERMISO.ELIMINAR_EMPLEADOS";//CAMBIAR ESTADO A INACTIVO

            //Proveedor
            public const String REGISTRAR_INFORME360 = "PERMISO.REGISTRAR_INFORME360";

        }
    }
}