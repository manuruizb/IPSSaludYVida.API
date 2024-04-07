using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Repositories
{
    public class OposicionDonacionRepository : IOposicionDonacionRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public OposicionDonacionRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Save(oposicionDonacion oposicion)
        {
            _dbContext.oposicionDonacions.Add(oposicion);
            await _dbContext.SaveChangesAsync();
            return oposicion.idDonacion;
        }
    }
}
