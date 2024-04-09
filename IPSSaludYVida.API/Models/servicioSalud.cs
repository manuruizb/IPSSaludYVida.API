using System;
using System.Collections.Generic;

namespace IPSSaludYVida.API.Models
{
    public partial class servicioSalud
    {
        public Guid idServicioSalud { get; set; }
        public string codigoPrestadorSalud { get; set; } = null!;
        public DateTime fechaInicioAtencion { get; set; }
        public TimeSpan horaInicioAtencion { get; set; }
        public string codigoModalidad { get; set; } = null!;
        public string grupoServicio { get; set; } = null!;
        public string entornoAtencion { get; set; } = null!;
        public string codigoViaIngreso { get; set; } = null!;
        public string codigoCausaAtencion { get; set; } = null!;
        public int idTriage { get; set; }
        public string codigoDiagnostico { get; set; } = null!;
        public string tipoDiagnostico { get; set; } = null!;
        public Guid idUsuario { get; set; }

        public virtual causaAtencion? codigoCausaAtencionNavigation { get; set; } = null!;
        public virtual diagnostico? codigoDiagnosticoNavigation { get; set; } = null!;
        public virtual modalidadServicio? codigoModalidadNavigation { get; set; } = null!;
        public virtual prestadoresSalud? codigoPrestadorSaludNavigation { get; set; } = null!;
        public virtual viaIngresoServicio? codigoViaIngresoNavigation { get; set; } = null!;
        public virtual triage? idTriageNavigation { get; set; } = null!;
        public virtual usuario? idUsuarioNavigation { get; set; } = null!;
    }
}
