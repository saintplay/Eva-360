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
            PermisosHelper.PERMISOS.LISTAR_ROLES,
            PermisosHelper.PERMISOS.EDITAR_USUARIOS,
            PermisosHelper.PERMISOS.LISTAR_USUARIOS,
            PermisosHelper.PERMISOS.ELIMINAR_USUARIOS,
            PermisosHelper.PERMISOS.VER_RENDIMIENTO
        };

        public static List<String> Supervisor = new List<String>() {
            PermisosHelper.PERMISOS.REGISTRAR_PUNTAJE,
            PermisosHelper.PERMISOS.EDITAR_PUNTAJE,
            PermisosHelper.PERMISOS.LISTAR_PUNTAJE,
            PermisosHelper.PERMISOS.LISTAR_EVALUACION360,
            PermisosHelper.PERMISOS.REGISTRAR_EMPLEADOS,
            PermisosHelper.PERMISOS.EDITAR_EMPLEADOS,
            PermisosHelper.PERMISOS.LISTAR_EMPLEADOS,
            PermisosHelper.PERMISOS.ELIMINAR_EMPLEADOS
        };

        public static List<String> Proveedor = new List<String>() {
            PermisosHelper.PERMISOS.REGISTRAR_INFORME360
        };

        public static List<String> Empleado = new List<String>() {
            PermisosHelper.PERMISOS.VER_OBJETIVOS,
            PermisosHelper.PERMISOS.VER_PUNTAJE,
            PermisosHelper.PERMISOS.VER_COMUNICACION_INTERNA,
            PermisosHelper.PERMISOS.CREAR_COMUNICACION_INTERNA
        };
    }
}