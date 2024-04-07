using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuarioDiscapacidadRepository : IUsuarioDiscapacidadRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuarioDiscapacidadRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Save(usuarioDiscapacidad usuarioDiscapacidades)
        {
            _dbContext.usuarioDiscapacidads.Add(usuarioDiscapacidades);
            await _dbContext.SaveChangesAsync();
        }
    }
}
