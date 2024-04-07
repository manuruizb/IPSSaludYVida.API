using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class oposicionDonacion
    {
        public oposicionDonacion()
        {
            usuarios = new HashSet<usuario>();
        }

        public int idDonacion { get; set; }
        public bool manifestacionOposicion { get; set; }
        public DateTime fecha { get; set; }

        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
