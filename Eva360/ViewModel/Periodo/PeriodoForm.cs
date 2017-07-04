using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eva360.ViewModel.Periodo
{
    public class PeriodoForm
    {
        public Int32? PeriodoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }
    }
}