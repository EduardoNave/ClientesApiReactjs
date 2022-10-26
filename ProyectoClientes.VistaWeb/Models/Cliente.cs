using System;
using System.Collections.Generic;

namespace ProyectoClientes.VistaWeb.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int? IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdGenero { get; set; }
        public DateTime? Creacion { get; set; }
        public byte? Activo { get; set; }
    }
}
