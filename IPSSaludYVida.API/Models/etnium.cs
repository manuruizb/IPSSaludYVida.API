using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class etnium
    {
        public etnium()
        {
            comunidadEtnicas = new HashSet<comunidadEtnica>();
        }

        public string codigoEtnia { get; set; } = null!;
        public string etnia { get; set; } = null!;

        public virtual ICollection<comunidadEtnica> comunidadEtnicas { get; set; }
    }
}
