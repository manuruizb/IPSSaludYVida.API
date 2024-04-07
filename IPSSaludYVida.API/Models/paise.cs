using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class paise
    {
        public paise()
        {
            usuarioPaises = new HashSet<usuarioPaise>();
            usuarios = new HashSet<usuario>();
        }

        public string idPais { get; set; } = null!;
        public string pais { get; set; } = null!;

        public virtual ICollection<usuarioPaise> usuarioPaises { get; set; }
        public virtual ICollection<usuario> usuarios { get; set; }
    }
}
