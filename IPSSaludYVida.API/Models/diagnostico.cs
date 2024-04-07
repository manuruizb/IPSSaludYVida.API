using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class diagnostico
    {
        public diagnostico()
        {
            servicioSaluds = new HashSet<servicioSalud>();
        }

        public string codigoDiagnostico { get; set; } = null!;
        public string diagnostico1 { get; set; } = null!;
        public string? padre { get; set; }

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
    }
}
