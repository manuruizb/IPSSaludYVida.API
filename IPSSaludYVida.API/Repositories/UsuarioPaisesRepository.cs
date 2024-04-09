using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuarioPaisesRepository : IUsuarioPaisesRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuarioPaisesRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Guid idUsuario)
        {
            var data = await _dbContext.usuarioPaises.Where(x => x.idUsuario == idUsuario).ToListAsync();

            _dbContext.usuarioPaises.RemoveRange(data);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Save(usuarioPaise usuarioPaises)
        {
            _dbContext.usuarioPaises.Add(usuarioPaises);
            await _dbContext.SaveChangesAsync();
        }
    }
}
