using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class modalidadServicio
    {
        public modalidadServicio()
        {
            servicioSaluds = new HashSet<servicioSalud>();
        }

        public string codigoModalidad { get; set; } = null!;
        public string modalidadServicio1 { get; set; } = null!;

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
    }
}
