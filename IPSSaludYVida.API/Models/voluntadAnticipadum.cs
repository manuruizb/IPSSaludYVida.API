using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class voluntadAnticipadum
    {
        public voluntadAnticipadum()
        {
            usuarios = new HashSet<usuario>();
        }

        public int idVoluntad { get; set; }
        public bool documentoVoluntad { get; set; }
        public DateTime fecha { get; set; }
        public string codigoPrestadorSalud { get; set; } = null!;

        public virtual prestadoresSalud? codigoPrestadorSaludNavigation { get; set; } = null!;
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
