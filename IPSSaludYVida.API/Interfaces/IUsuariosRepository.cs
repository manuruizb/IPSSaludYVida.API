using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Guid> Save(usuario user);
    }
}
