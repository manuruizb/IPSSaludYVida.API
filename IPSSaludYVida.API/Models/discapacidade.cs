using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class discapacidade
    {
        public discapacidade()
        {
            usuarioDiscapacidads = new HashSet<usuarioDiscapacidad>();
        }

        public string codigoDiscapacidad { get; set; } = null!;
        public string categoriaDiscapacidad { get; set; } = null!;

        public virtual ICollection<usuarioDiscapacidad> usuarioDiscapacidads { get; set; }
    }
}
