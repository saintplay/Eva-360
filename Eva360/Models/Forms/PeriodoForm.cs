using System;
using System.ComponentModel.DataAnnotations;

namespace Eva360.Models.Forms
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