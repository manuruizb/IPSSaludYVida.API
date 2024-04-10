using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class TriageRepository : ITriageRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public TriageRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Save(triage triag)
        {
            _dbContext.triages.Add(triag);
            await _dbContext.SaveChangesAsync();
            return triag.idTriage;
        }

        public async Task Update(triage triag)
        {
            var triageDb = await _dbContext.triages.FirstOrDefaultAsync(x => x.idTriage == triag.idTriage);

            if (triageDb == null)
            {
                throw new Exception("No se encuentra un registro de triage.");
            }

            triageDb.fechaTriage = triag.fechaTriage;
            triageDb.horaTriage = triag.horaTriage;
            triageDb.clasificacionTriage = triag.clasificacionTriage;

            await _dbContext.SaveChangesAsync();

        }
    }
}
