using System;
using System.Collections.Generic;

namespace ProyectoClientes.VistaWeb.Models
{
    public partial class TemasIntere
    {
        public int IdTemaInteres { get; set; }
        public string Tema { get; set; } = null!;
        public byte? Activo { get; set; }
    }
}
