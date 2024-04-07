using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Repositories
{
    public class VoluntadAnticipadaRepository : IVoluntadAnticipadaRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public VoluntadAnticipadaRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Save(voluntadAnticipadum voluntad)
        {
            _dbContext.voluntadAnticipada.Add(voluntad);
            await _dbContext.SaveChangesAsync();
            return voluntad.idVoluntad;
        }
    }
}
