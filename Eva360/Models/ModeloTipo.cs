using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eva360.Models
{
    public static class ModeloTipo
    {
        public static List<String> Roles { get; set; } = new List<String>() {
            "ADMIN",
            "SUPERVISOR",
            "PROVEEDOR",
            "EMPLEADO",
        };
    }
}