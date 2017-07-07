using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eva360.Models;

namespace Eva360.ViewModel.ComunicacionInterna
{
    public class ComunicacionInternaForm
    {
        [Required]
        public Int32 EmpleadoId { get; set; }

        [Required]
        public String Contenido { get; set; } = String.Empty;
    }
}