using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IServicioSaludRepository
    {
        Task Save(servicioSalud service);

        Task<List<servicioSalud>> SearchByIdUsuario(Guid idUsuario, int page, int pagesize);

        Task Update(servicioSalud service);

        Task<int> CountAll();

        Task<servicioSalud?> SearchByIdService(Guid idServicioSalud);
    }
}
