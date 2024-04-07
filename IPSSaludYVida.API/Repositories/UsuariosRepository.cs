using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuariosRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Save(usuario user)
        {
            user.idUsuario = Guid.NewGuid();
            _dbContext.usuarios.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.idUsuario;
        }
    }
}
