using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IOposicionDonacionRepository
    {
        Task<int> Save(oposicionDonacion oposicion);

        Task Update(oposicionDonacion oposicion);
    }
}
