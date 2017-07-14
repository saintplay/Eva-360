using System;
using System.ComponentModel.DataAnnotations;

namespace Eva360.Models.Forms
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