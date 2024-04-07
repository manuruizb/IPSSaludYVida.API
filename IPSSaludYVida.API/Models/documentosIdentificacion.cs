using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class documentosIdentificacion
    {
        public documentosIdentificacion()
        {
            usuarios = new HashSet<usuario>();
        }

        public string tipoDocumento { get; set; } = null!;
        public string descripcionDocumento { get; set; } = null!;

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
