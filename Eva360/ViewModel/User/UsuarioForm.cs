using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eva360.ViewModel.User
{
    public class UsuarioFormViewModel
    {
        public int ? UsuarioId { get; set; }

        [Required]
        public string Nombre { get; set; } = String.Empty;

        [Required]
        public string Apellido { get; set; } = String.Empty;

        [Required]
        public string Codigo { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        public int TipoDocumentoId { get; set; }

        public string NroDocumento { get; set; }
    }
}