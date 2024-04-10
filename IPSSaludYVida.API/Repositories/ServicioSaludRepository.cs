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

        public async Task Update(servicioSalud service)
        {
            var serviceDb = await _dbContext.servicioSaluds.FirstOrDefaultAsync(x => x.idServicioSalud == service.idServicioSalud);

            if(serviceDb == null)
            {
                throw new Exception("No existe el servicio de salud.");
            }

            serviceDb.codigoPrestadorSalud = service.codigoPrestadorSalud;
            serviceDb.fechaInicioAtencion = service.fechaInicioAtencion;
            serviceDb.horaInicioAtencion = service.horaInicioAtencion;
            serviceDb.codigoModalidad = service.codigoModalidad;
            serviceDb.grupoServicio = service.grupoServicio;
            serviceDb.entornoAtencion = service.entornoAtencion;
            serviceDb.codigoViaIngreso = service.codigoViaIngreso;
            serviceDb.codigoCausaAtencion = service.codigoCausaAtencion;
            serviceDb.codigoDiagnostico = service.codigoDiagnostico;

            await _dbContext.SaveChangesAsync();

        }
    }
}
