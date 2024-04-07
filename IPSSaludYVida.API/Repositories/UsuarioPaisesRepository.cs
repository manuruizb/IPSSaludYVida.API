using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuarioPaisesRepository : IUsuarioPaisesRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuarioPaisesRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Save(usuarioPaise usuarioPaises)
        {
            _dbContext.usuarioPaises.Add(usuarioPaises);
            await _dbContext.SaveChangesAsync();
        }
    }
}
