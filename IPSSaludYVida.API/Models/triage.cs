using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class triage
    {
        public triage()
        {
            servicioSaluds = new HashSet<servicioSalud>();
        }

        public int idTriage { get; set; }
        public DateTime fechaTriage { get; set; }
        public TimeSpan horaTriage { get; set; }
        public string clasificacionTriage { get; set; } = null!;

        public virtual ICollection<servicioSalud> servicioSaluds { get; set; }
    }
}
