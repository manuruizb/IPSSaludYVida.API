using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class entidadesAdministradorasSalud
    {
        public entidadesAdministradorasSalud()
        {
            usuarios = new HashSet<usuario>();
        }

        public string codigoEntidad { get; set; } = null!;
        public string nombreEntidad { get; set; } = null!;

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
