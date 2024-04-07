using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class ocupacion
    {
        public ocupacion()
        {
            usuarios = new HashSet<usuario>();
        }

        public string codigoOcupacion { get; set; } = null!;
        public string ocupacion1 { get; set; } = null!;
        public string? padre { get; set; }

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
