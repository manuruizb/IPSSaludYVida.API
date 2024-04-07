using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class usuarioDiscapacidad
    {
        public Guid idUsuario { get; set; }
        public string codigoDiscapacidad { get; set; } = null!;
        public int idUsuarioDiscapacidad { get; set; }

        public virtual discapacidade? codigoDiscapacidadNavigation { get; set; } = null!;
        public virtual usuario? idUsuarioNavigation { get; set; } = null!;
    }
}
