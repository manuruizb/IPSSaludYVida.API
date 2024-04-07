using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class departamentoMunicipio
    {
        public departamentoMunicipio()
        {
            usuarios = new HashSet<usuario>();
        }

        public string codigoDeparMuni { get; set; } = null!;
        public string deparMuni { get; set; } = null!;
        public string? padre { get; set; }

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
