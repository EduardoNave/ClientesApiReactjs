using System;
using System.Collections.Generic;

namespace ProyectoClientes.VistaWeb.Models
{
    public partial class TiposDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public byte? Activo { get; set; }
    }
}
