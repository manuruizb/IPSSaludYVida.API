using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class usuarioPaise
    {
        public Guid idUsuario { get; set; }
        public string idPais { get; set; } = null!;
        public int idUsuarioPaises { get; set; }

        public virtual paise? idPaisNavigation { get; set; } = null!;
        public virtual usuario? idUsuarioNavigation { get; set; } = null!;
    }
}
