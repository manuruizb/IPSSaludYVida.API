using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IVoluntadAnticipadaRepository
    {
        Task<int?> Save(voluntadAnticipadum voluntad);

        Task<int?> Update(voluntadAnticipadum voluntad);
    }
}
