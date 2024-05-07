using IPSSaludYVida.API.Db;
using IPSSaludYVida.API.Interfaces;
using IPSSaludYVida.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public UsuariosRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAll()
        {
            return await _dbContext.usuarios.CountAsync();
        }

        public async Task<List<usuario>> GetAll(int page, int pagesize, string? searchparam)
        {

            int skip = (page - 1) * pagesize;

            var query = _dbContext.usuarios.AsQueryable();

            if (!string.IsNullOrEmpty(searchparam))
            {
                query = query.Where(u => u.numeroDocumento == searchparam);
            }

            var usuarios = await query.Skip(skip).Take(pagesize).ToListAsync();

            return usuarios;
        }

        public async Task<Guid> Save(usuario user)
        {
            user.idUsuario = Guid.NewGuid(); //Esto crea la llave primaria, el uniqueidentifier corresponde a GUID, porque como no hay SP, no se crea automáticamente. 
            _dbContext.usuarios.Add(user);
            await _dbContext.SaveChangesAsync();
            return user.idUsuario;
        }

        public async Task<usuario?> SearchByDocument(string document)
        {
            return await _dbContext.usuarios
                .Include(u => u.idDonacionNavigation)
                .Include(u => u.idVoluntadNavigation)
                .Include(u => u.codigoOcupacionNavigation)
                .Include(u => u.codigoDeparMuniNavigation)
                .Include(u => u.usuarioPaises)!
                    .ThenInclude(up=> up.idPaisNavigation)
                .Include(u => u.usuarioDiscapacidads)!
                    .ThenInclude(ud=> ud.codigoDiscapacidadNavigation)
                .Include(u => u.codigoComunidadNavigation)
                .Include(c=> c.codigoComunidadNavigation!.codigoEtniaNavigation)
                .Where(x => x.numeroDocumento.Equals(document))
                    .FirstOrDefaultAsync();
        }

        public async Task UpdateUser(usuario user)
        {
            var userDb = await _dbContext.usuarios.FirstOrDefaultAsync(x => x.idUsuario == user.idUsuario);

            if (userDb == null)
            {
                throw new Exception("No existe el usuario.");
            }

            userDb.tipoDocumento = user.tipoDocumento;
            userDb.numeroDocumento = user.numeroDocumento;
            userDb.primerNombre = user.primerNombre;
            userDb.segundoNombre = user.segundoNombre;
            userDb.primerApellido = user.primerApellido;
            userDb.segundoApellido = user.segundoApellido;
            userDb.fechaNacimiento = user.fechaNacimiento;
            userDb.horaNacimiento = user.horaNacimiento;
            userDb.sexoBiologico = user.sexoBiologico;
            userDb.identidadGenero = user.identidadGenero;
            userDb.codigoOcupacion = user.codigoOcupacion;
            userDb.idPaisResidencia = user.idPaisResidencia;
            userDb.codigoDeparMuni = user.codigoDeparMuni;
            userDb.codigoComunidad = user.codigoComunidad;
            userDb.zonaResidencia = user.zonaResidencia;
            userDb.codigoEntidad = user.codigoEntidad;
            userDb.idDonacion = user.idDonacion;
            userDb.idVoluntad= user.idVoluntad;

            await _dbContext.SaveChangesAsync();
        }
    }
}
