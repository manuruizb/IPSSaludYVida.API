using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class comunidadEtnica
    {
        public comunidadEtnica()
        {
            usuarios = new HashSet<usuario>();
        }

        public string codigoComunidad { get; set; } = null!;
        public string comunidad { get; set; } = null!;
        public string codigoEtnia { get; set; } = null!;

        public virtual etnium codigoEtniaNavigation { get; set; } = null!;
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
