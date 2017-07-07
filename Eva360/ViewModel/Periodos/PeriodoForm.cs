using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eva360.ViewModel.Periodos
{
    public class PeriodoForm
    {
        public Int32? PeriodoId { get; set; }

        [Required]
        public string Nombre { get; set; } = String.Empty;

        [Required]
        public string Estado { get; set; } = String.Empty;

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }
    }
}