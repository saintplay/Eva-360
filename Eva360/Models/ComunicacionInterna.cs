//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eva360.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComunicacionInterna
    {
        public int ComunicacionInterna1 { get; set; }
        public int EmpleadoId { get; set; }
        public string Contenido { get; set; }
        public int UsuarioCreacionId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<int> UsuarioModificacionId { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}