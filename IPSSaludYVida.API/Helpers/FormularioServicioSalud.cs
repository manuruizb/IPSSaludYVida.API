using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Helpers
{
    public class FormularioServicioSalud
    {
        public servicioSalud service { get; set; } = null!;
        public string document { get; set; } = null!;
        public triage triag {  get; set; } = null!;
    }
}
