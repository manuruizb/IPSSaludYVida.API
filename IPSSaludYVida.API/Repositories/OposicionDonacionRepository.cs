using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task Update(oposicionDonacion oposicion)
        {
            var oposicionDb = await _dbContext.oposicionDonacions.FirstOrDefaultAsync(x => x.idDonacion.Equals(oposicion.idDonacion));

            if (oposicionDb == null)
            {
                throw new Exception("No se encuentra un registro de oposición a la donación.");
            }

            oposicionDb.manifestacionOposicion = oposicion.manifestacionOposicion;
            oposicionDb.fecha = oposicion.fecha;

            await _dbContext.SaveChangesAsync();
        }
    }
}
