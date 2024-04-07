using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class viaIngresoServicio
    {
        public viaIngresoServicio()
        {
            servicioSaluds = new HashSet<servicioSalud>();
        }

        public string codigoViaIngreso { get; set; } = null!;
        public string viaIngresoServicio1 { get; set; } = null!;

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
    }
}
