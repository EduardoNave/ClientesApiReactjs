using System;
using System.Collections.Generic;

namespace ProyectoClientes.VistaWeb.Models
{
    public partial class InteresesCliente
    {
        public int IdInteresCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdTemaInteres { get; set; }
        public byte? Activo { get; set; }
    }
}
