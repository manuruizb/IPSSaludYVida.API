using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Helpers
{
    public class FormularioUsuario
    {
        public usuario user { get; set; } = null!;
        public List<usuarioPaise> paises { get; set; } = null!;
        public List<usuarioDiscapacidad> discapacidades { get; set; } = null!;
        public oposicionDonacion opoDonacion { get; set; } = null!;
        public voluntadAnticipadum voluntad {  get; set; } = null!;
    }
}
