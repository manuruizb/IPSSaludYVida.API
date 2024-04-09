using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;

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
    }
}
