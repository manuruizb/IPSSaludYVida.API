using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IServicioSaludRepository
    {
        Task Save(servicioSalud service);

        Task<List<servicioSalud>> SearchByIdUsuario(Guid idUsuario);
    }
}
