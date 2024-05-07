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
        public async Task<int?> Save(oposicionDonacion oposicion)
        {
            _dbContext.oposicionDonacions.Add(oposicion);
            await _dbContext.SaveChangesAsync();
            return oposicion.idDonacion;
        }

        public async Task<int?> Update(oposicionDonacion oposicion)
        {
            var oposicionDb = await _dbContext.oposicionDonacions.FirstOrDefaultAsync(x => x.idDonacion.Equals(oposicion.idDonacion));

            if (oposicionDb == null)
            {
                if (oposicion.idDonacion == 0 && oposicion.manifestacionOposicion) {
                    oposicion.idDonacion = null;
                    return await Save(oposicion);
                }


                return null;
            }

            oposicionDb.manifestacionOposicion = oposicion.manifestacionOposicion;
            oposicionDb.fecha = oposicion.fecha;

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(oposicion.idDonacion);
        }
    }
}
