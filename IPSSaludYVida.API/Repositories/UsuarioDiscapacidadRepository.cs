using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuarioDiscapacidadRepository : IUsuarioDiscapacidadRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuarioDiscapacidadRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Guid idUsuario)
        {
            var data = await _dbContext.usuarioDiscapacidads.Where(x => x.idUsuario == idUsuario).ToListAsync();

            _dbContext.usuarioDiscapacidads.RemoveRange(data);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Save(usuarioDiscapacidad usuarioDiscapacidades)
        {
            _dbContext.usuarioDiscapacidads.Add(usuarioDiscapacidades);
            await _dbContext.SaveChangesAsync();
        }
    }
}
