using IPSSaludYVida.API.Db;
using Microsoft.EntityFrameworkCore;

namespace IPSSaludYVida.API
{
    public class MasterRepository : IMasterRepository
    {
        private readonly dbIPSSaludYVidaContext _dbContext;
        public MasterRepository(dbIPSSaludYVidaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<dynamic?> GetAll(TablesEnum table, string? param)
        {
            switch (table)
            {
                case TablesEnum.Paises:
                    return await _dbContext.paises.ToListAsync();
                case TablesEnum.Etnia:
                    return await _dbContext.etnia.ToListAsync();
                case TablesEnum.CausaAtencion:
                    return await _dbContext.causaAtencions.ToListAsync();
                case TablesEnum.ComunidadEtnica:
                    return await _dbContext.comunidadEtnicas.ToListAsync();
                case TablesEnum.Departamento:
                    return await 
                        _dbContext.departamentoMunicipios
                        .Where(x => x.padre!.Equals(null))
                        .OrderBy(x => x.deparMuni)
                        .ToListAsync();
                case TablesEnum.Municipio:
                    return await
                        _dbContext.departamentoMunicipios
                        .Where(x => x.padre!.Equals(param))
                        .OrderBy(x => x.deparMuni)
                        .ToListAsync();
                case TablesEnum.Diagnostico:
                    return await _dbContext.diagnosticos
                        .Where(x => x.padre!.Equals(param))
                        .OrderBy(x => x.codigoDiagnostico)
                        .ToListAsync();
                case TablesEnum.Discapacidades:
                    return await _dbContext.discapacidades.ToListAsync();
                case TablesEnum.DocumentosIdentificacion:
                    return await _dbContext.documentosIdentificacions.ToListAsync();
                case TablesEnum.EntidadesAdministradorasSalud:
                    return await _dbContext.entidadesAdministradorasSaluds.ToListAsync();
                case TablesEnum.ModalidadServicios:
                    return await _dbContext.modalidadServicios.ToListAsync();
                case TablesEnum.Ocupacion:
                    return await _dbContext.ocupacions
                        .Where(x => x.padre!.Equals(param))
                        .OrderBy(x => x.ocupacion1)
                        .ToListAsync();
                case TablesEnum.PrestadoresSalud:
                    return await _dbContext.prestadoresSaluds.ToListAsync();
                case TablesEnum.Triage:
                    return await _dbContext.triages.ToListAsync();
                case TablesEnum.ViaIngresoServicio:
                    return await _dbContext.viaIngresoServicios.ToListAsync();
            }
            return null!;
        }
    }
}
