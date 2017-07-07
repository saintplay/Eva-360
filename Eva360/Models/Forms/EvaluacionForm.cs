using System;
using System.ComponentModel.DataAnnotations;

namespace Eva360.Models.Forms
{
    public class EvaluacionForm
    {
        public Int32? EvaluacionId { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public Decimal PorcentajeAvance { get; set; }

        [Required]
        public Int32 SupervisorId { get; set; }

        [Required]
        public Int32 EmpleadoId { get; set; }

        [Required]
        public Int32 PeriodoId { get; set; }

        public Int32 ProveedorId { get; set; }

        public String RutaInforme { get; set; }
    }
}