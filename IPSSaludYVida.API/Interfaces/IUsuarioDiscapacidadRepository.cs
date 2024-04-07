using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IUsuarioDiscapacidadRepository
    {
        Task Save(usuarioDiscapacidad usuarioDiscapacidades);
    }
}
