using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class usuario
    {
        public usuario()
        {
            idUsuario = Guid.NewGuid();
            servicioSaluds = new HashSet<servicioSalud>();
            usuarioDiscapacidads = new HashSet<usuarioDiscapacidad>();
            usuarioPaises = new HashSet<usuarioPaise>();
        }

        public Guid idUsuario { get; set; }
        public string? tipoDocumento { get; set; }
        public string numeroDocumento { get; set; } = null!;
        public string primerNombre { get; set; } = null!;
        public string? segundoNombre { get; set; }
        public string primerApellido { get; set; } = null!;
        public string? segundoApellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public TimeSpan? horaNacimiento { get; set; }
        public string sexoBiologico { get; set; } = null!;
        public string identidadGenero { get; set; } = null!;
        public string codigoOcupacion { get; set; } = null!;
        public int idDonacion { get; set; }
        public int idVoluntad { get; set; }
        public string idPaisResidencia { get; set; } = null!;
        public string codigoDeparMuni { get; set; } = null!;
        public string codigoComunidad { get; set; } = null!;
        public string zonaResidencia { get; set; } = null!;
        public string codigoEntidad { get; set; } = null!;

        public virtual comunidadEtnica? codigoComunidadNavigation { get; set; } = null!;
        public virtual departamentoMunicipio? codigoDeparMuniNavigation { get; set; } = null!;
        public virtual entidadesAdministradorasSalud? codigoEntidadNavigation { get; set; } = null!;
        public virtual ocupacion? codigoOcupacionNavigation { get; set; } = null!;
        public virtual oposicionDonacion? idDonacionNavigation { get; set; } = null!;
        public virtual paise? idPaisResidenciaNavigation { get; set; } = null!;
        public virtual voluntadAnticipadum? idVoluntadNavigation { get; set; } = null!;
        public virtual documentosIdentificacion? tipoDocumentoNavigation { get; set; }
        public virtual ICollection<servicioSalud>? servicioSaluds { get; set; }
        public virtual ICollection<usuarioDiscapacidad>? usuarioDiscapacidads { get; set; }
        public virtual ICollection<usuarioPaise>? usuarioPaises { get; set; }
    }
}
