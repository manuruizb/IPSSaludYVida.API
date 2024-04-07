using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class causaAtencion
    {
        public causaAtencion()
        {
            servicioSaluds = new HashSet<servicioSalud>();
        }

        public string codigoCausaAtencion { get; set; } = null!;
        public string causaAtencion1 { get; set; } = null!;

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
    }
}
