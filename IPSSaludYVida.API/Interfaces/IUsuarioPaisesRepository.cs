using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IUsuarioPaisesRepository
    {
        Task Save(usuarioPaise usuarioPaises);

        Task Delete(Guid idUsuario);
    }
}
