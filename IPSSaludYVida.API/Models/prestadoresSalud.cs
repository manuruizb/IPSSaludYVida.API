using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class prestadoresSalud
    {
        public prestadoresSalud()
        {
            servicioSaluds = new HashSet<servicioSalud>();
            voluntadAnticipada = new HashSet<voluntadAnticipadum>();
        }

        public string codigoPrestadorSalud { get; set; } = null!;
        public string prestadorSalud { get; set; } = null!;

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
        public virtual ICollection<voluntadAnticipadum> voluntadAnticipada { get; set; }
    }
}
