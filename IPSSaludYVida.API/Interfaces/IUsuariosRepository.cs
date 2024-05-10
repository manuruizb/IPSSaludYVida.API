using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Guid> Save(usuario user);

        Task<usuario?> SearchByDocument(string document);

        Task UpdateUser(usuario user);

        Task<List<usuario>> GetAll(int page, int pagesize, string? searchparam);

        Task<int> CountAll();
    }
}
