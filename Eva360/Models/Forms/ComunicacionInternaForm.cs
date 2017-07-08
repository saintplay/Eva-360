using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eva360.Models;

namespace Eva360.Models.Forms
{
    public class ComunicacionInternaForm
    {
        public List<ComunicacionInterna> LstCom { get; set; }

        [Required]
        public Int32 EmpleadoId { get; set; }

        [Required]
        public String Contenido { get; set; } = String.Empty;
    }
}