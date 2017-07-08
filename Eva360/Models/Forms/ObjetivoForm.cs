using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Eva360.Models;

namespace Eva360.Models.Forms
{
    public class ObjetivoForm
    {
        public Int32? ObjetivoId { get; set; }

        [Required]
        public String Nombre { get; set; } = String.Empty;

        [Required]
        public Int32 PeriodoId { get; set; } //

        [Required]
        public Int32 Orden { get; set; }

        [Required]
        public String Descripcion { get; set; } = String.Empty;
    }
}