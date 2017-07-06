using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eva360.ViewModel.User
{
    public class UsuarioForm
    {
        public Int32 ? UsuarioId { get; set; }

        [Required]
        public String Nombre { get; set; } = String.Empty;

        [Required]
        public String Apellido { get; set; } = String.Empty;

        [Required]
        public String Codigo { get; set; } = String.Empty;

        [Required]
        public String Email { get; set; } = String.Empty;

        [Required]
        public String Password { get; set; } = String.Empty;

        [Required]
        public Int32 TipoDocumentoId { get; set; }

        [Required]
        public String NroDocumento { get; set; }

        [Required]
        public String Rol { get; set; } = String.Empty;

        public String Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}