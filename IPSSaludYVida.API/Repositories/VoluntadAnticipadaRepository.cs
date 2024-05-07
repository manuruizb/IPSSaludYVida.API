using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class VoluntadAnticipadaRepository : IVoluntadAnticipadaRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public VoluntadAnticipadaRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int?> Save(voluntadAnticipadum voluntad)
        {
            _dbContext.voluntadAnticipada.Add(voluntad);
            await _dbContext.SaveChangesAsync();
            return voluntad.idVoluntad;
        }

        public async Task<int?> Update(voluntadAnticipadum voluntad)
        {
            var voluntadDb = await _dbContext.voluntadAnticipada.FirstOrDefaultAsync(x => x.idVoluntad == voluntad.idVoluntad);

            if (voluntadDb == null)
            {
                if (voluntad.idVoluntad == 0 && voluntad.documentoVoluntad)
                {
                    voluntad.idVoluntad = null;
                    return await Save(voluntad);
                }

                return null;

            }

            voluntadDb.documentoVoluntad = voluntad.documentoVoluntad;
            voluntadDb.fecha = voluntad.fecha;
            voluntadDb.codigoPrestadorSalud = voluntad.codigoPrestadorSalud;

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(voluntad.idVoluntad);
        }
    }
}
