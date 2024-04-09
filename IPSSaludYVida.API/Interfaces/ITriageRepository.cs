using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface ITriageRepository
    {
        Task<int> Save(triage triag);
    }
}
