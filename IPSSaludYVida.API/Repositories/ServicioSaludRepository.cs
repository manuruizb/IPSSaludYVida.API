using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class ServicioSaludRepository : IServicioSaludRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public ServicioSaludRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task Save(servicioSalud service)
        {
            service.idServicioSalud = Guid.NewGuid();
            _dbContext.servicioSaluds.Add(service);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<servicioSalud>> SearchByIdUsuario(Guid idUsuario)
        {
            return await _dbContext.servicioSaluds.
                Where(x => x.idUsuario == idUsuario).
                ToListAsync();
        }
    }
}
