using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IPSSaludYVida.API.Models;

namespace IPSSaludYVida.API.Db
{
    public partial class dbIPSSaludYVidaContext : DbContext
    {
        public dbIPSSaludYVidaContext()
        {
        }

        public dbIPSSaludYVidaContext(DbContextOptions<dbIPSSaludYVidaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<causaAtencion> causaAtencions { get; set; } = null!;
        public virtual DbSet<comunidadEtnica> comunidadEtnicas { get; set; } = null!;
        public virtual DbSet<departamentoMunicipio> departamentoMunicipios { get; set; } = null!;
        public virtual DbSet<diagnostico> diagnosticos { get; set; } = null!;
        public virtual DbSet<discapacidade> discapacidades { get; set; } = null!;
        public virtual DbSet<documentosIdentificacion> documentosIdentificacions { get; set; } = null!;
        public virtual DbSet<entidadesAdministradorasSalud> entidadesAdministradorasSaluds { get; set; } = null!;
        public virtual DbSet<etnium> etnia { get; set; } = null!;
        public virtual DbSet<modalidadServicio> modalidadServicios { get; set; } = null!;
        public virtual DbSet<ocupacion> ocupacions { get; set; } = null!;
        public virtual DbSet<oposicionDonacion> oposicionDonacions { get; set; } = null!;
        public virtual DbSet<paise> paises { get; set; } = null!;
        public virtual DbSet<prestadoresSalud> prestadoresSaluds { get; set; } = null!;
        public virtual DbSet<servicioSalud> servicioSaluds { get; set; } = null!;
        public virtual DbSet<triage> triages { get; set; } = null!;
        public virtual DbSet<usuario> usuarios { get; set; } = null!;
        public virtual DbSet<usuarioDiscapacidad> usuarioDiscapacidads { get; set; } = null!;
        public virtual DbSet<usuarioPaise> usuarioPaises { get; set; } = null!;
        public virtual DbSet<viaIngresoServicio> viaIngresoServicios { get; set; } = null!;
        public virtual DbSet<voluntadAnticipadum> voluntadAnticipada { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<causaAtencion>(entity =>
            {
                entity.HasKey(e => e.codigoCausaAtencion)
                    .HasName("PK__causaAte__BEEA68A258CE9E87");

                entity.ToTable("causaAtencion");

                entity.Property(e => e.codigoCausaAtencion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.causaAtencion1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("causaAtencion");
            });

            modelBuilder.Entity<comunidadEtnica>(entity =>
            {
                entity.HasKey(e => e.codigoComunidad)
                    .HasName("PK__comunida__07532745D8095C35");

                entity.ToTable("comunidadEtnica");

                entity.Property(e => e.codigoComunidad)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.codigoEtnia)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.comunidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.codigoEtniaNavigation)
                    .WithMany(p => p.comunidadEtnicas)
                    .HasForeignKey(d => d.codigoEtnia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__comunidad__codig__37A5467C");
            });

            modelBuilder.Entity<departamentoMunicipio>(entity =>
            {
                entity.HasKey(e => e.codigoDeparMuni)
                    .HasName("PK__departam__AED4D313004C69D6");

                entity.ToTable("departamentoMunicipio");

                entity.Property(e => e.codigoDeparMuni)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.deparMuni)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.padre)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<diagnostico>(entity =>
            {
                entity.HasKey(e => e.codigoDiagnostico)
                    .HasName("PK__diagnost__433527E46044AFB2");

                entity.ToTable("diagnostico");

                entity.Property(e => e.codigoDiagnostico)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.diagnostico1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("diagnostico");

                entity.Property(e => e.padre)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<discapacidade>(entity =>
            {
                entity.HasKey(e => e.codigoDiscapacidad)
                    .HasName("PK__discapac__4E4E2EAAD611E737");

                entity.Property(e => e.codigoDiscapacidad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.categoriaDiscapacidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<documentosIdentificacion>(entity =>
            {
                entity.HasKey(e => e.tipoDocumento)
                    .HasName("PK__document__8F9AD5171351FC4F");

                entity.ToTable("documentosIdentificacion");

                entity.Property(e => e.tipoDocumento)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.descripcionDocumento)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<entidadesAdministradorasSalud>(entity =>
            {
                entity.HasKey(e => e.codigoEntidad)
                    .HasName("PK__entidade__77B3EB08371AE9EF");

                entity.ToTable("entidadesAdministradorasSalud");

                entity.Property(e => e.codigoEntidad)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.nombreEntidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<etnium>(entity =>
            {
                entity.HasKey(e => e.codigoEtnia)
                    .HasName("PK__etnia__13919F6DE650E85A");

                entity.Property(e => e.codigoEtnia)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.etnia)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<modalidadServicio>(entity =>
            {
                entity.HasKey(e => e.codigoModalidad)
                    .HasName("PK__modalida__4925B3AEAC0EDFA6");

                entity.Property(e => e.codigoModalidad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.modalidadServicio1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("modalidadServicio");
            });

            modelBuilder.Entity<ocupacion>(entity =>
            {
                entity.HasKey(e => e.codigoOcupacion)
                    .HasName("PK__ocupacio__C0C6BAB75B9EEA67");

                entity.ToTable("ocupacion");

                entity.Property(e => e.codigoOcupacion)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ocupacion1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ocupacion");

                entity.Property(e => e.padre)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<oposicionDonacion>(entity =>
            {
                entity.HasKey(e => e.idDonacion)
                    .HasName("PK__oposicio__B2601917843ADD9A");

                entity.ToTable("oposicionDonacion");

                entity.Property(e => e.fecha).HasColumnType("date");
            });

            modelBuilder.Entity<paise>(entity =>
            {
                entity.HasKey(e => e.idPais)
                    .HasName("PK__paises__BD2285E332C0E713");

                entity.Property(e => e.idPais)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.pais)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<prestadoresSalud>(entity =>
            {
                entity.HasKey(e => e.codigoPrestadorSalud)
                    .HasName("PK__prestado__A612FEEBC8F3B30E");

                entity.ToTable("prestadoresSalud");

                entity.Property(e => e.codigoPrestadorSalud)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.prestadorSalud)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<servicioSalud>(entity =>
            {
                entity.HasKey(e => e.idServicioSalud)
                    .HasName("PK__servicio__12B4E8121312BD64");

                entity.ToTable("servicioSalud");

                entity.Property(e => e.idServicioSalud).ValueGeneratedNever();

                entity.Property(e => e.codigoCausaAtencion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.codigoDiagnostico)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.codigoModalidad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.codigoPrestadorSalud)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.codigoViaIngreso)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.entornoAtencion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.fechaInicioAtencion).HasColumnType("date");

                entity.Property(e => e.grupoServicio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.tipoDiagnostico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.codigoCausaAtencionNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.codigoCausaAtencion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__codig__59063A47");

                entity.HasOne(d => d.codigoDiagnosticoNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.codigoDiagnostico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__codig__5AEE82B9");

                entity.HasOne(d => d.codigoModalidadNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.codigoModalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__codig__571DF1D5");

                entity.HasOne(d => d.codigoPrestadorSaludNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.codigoPrestadorSalud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__codig__5629CD9C");

                entity.HasOne(d => d.codigoViaIngresoNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.codigoViaIngreso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__codig__5812160E");

                entity.HasOne(d => d.idTriageNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.idTriage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__idTri__59FA5E80");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.servicioSaluds)
                    .HasForeignKey(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__servicioS__idUsu__5BE2A6F2");
            });

            modelBuilder.Entity<triage>(entity =>
            {
                entity.HasKey(e => e.idTriage)
                    .HasName("PK__triage__37E5A517139AFE0D");

                entity.ToTable("triage");

                entity.Property(e => e.clasificacionTriage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fechaTriage).HasColumnType("date");
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario)
                    .HasName("PK__usuarios__645723A62DC654A7");

                entity.HasIndex(e => e.numeroDocumento, "UQ__usuarios__4CC511E40963A6F2")
                    .IsUnique();

                entity.Property(e => e.idUsuario).ValueGeneratedNever();

                entity.Property(e => e.codigoComunidad)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.codigoDeparMuni)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.codigoEntidad)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.codigoOcupacion)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.fechaNacimiento).HasColumnType("date");

                entity.Property(e => e.idPaisResidencia)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.identidadGenero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.numeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.primerApellido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.primerNombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.segundoApellido)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.segundoNombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.sexoBiologico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.tipoDocumento)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.zonaResidencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.codigoComunidadNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.codigoComunidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__codigo__4316F928");

                entity.HasOne(d => d.codigoDeparMuniNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.codigoDeparMuni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__codigo__4222D4EF");

                entity.HasOne(d => d.codigoEntidadNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.codigoEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__codigo__440B1D61");

                entity.HasOne(d => d.codigoOcupacionNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.codigoOcupacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__codigo__3E52440B");

                entity.HasOne(d => d.idDonacionNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.idDonacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__idDona__3F466844");

                entity.HasOne(d => d.idPaisResidenciaNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.idPaisResidencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__idPais__412EB0B6");

                entity.HasOne(d => d.idVoluntadNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.idVoluntad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarios__idVolu__403A8C7D");

                entity.HasOne(d => d.tipoDocumentoNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.tipoDocumento)
                    .HasConstraintName("FK__usuarios__tipoDo__3D5E1FD2");
            });

            modelBuilder.Entity<usuarioDiscapacidad>(entity =>
            {
                entity.HasKey(e => e.idUsuarioDiscapacidad);

                entity.ToTable("usuarioDiscapacidad");

                entity.Property(e => e.codigoDiscapacidad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.codigoDiscapacidadNavigation)
                    .WithMany(p => p.usuarioDiscapacidads)
                    .HasForeignKey(d => d.codigoDiscapacidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioDi__codig__49C3F6B7");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.usuarioDiscapacidads)
                    .HasForeignKey(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioDi__idUsu__48CFD27E");
            });

            modelBuilder.Entity<usuarioPaise>(entity =>
            {
                entity.HasKey(e => e.idUsuarioPaises);

                entity.Property(e => e.idPais)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.idPaisNavigation)
                    .WithMany(p => p.usuarioPaises)
                    .HasForeignKey(d => d.idPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioPa__idPai__46E78A0C");

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.usuarioPaises)
                    .HasForeignKey(d => d.idUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuarioPa__idUsu__45F365D3");
            });

            modelBuilder.Entity<viaIngresoServicio>(entity =>
            {
                entity.HasKey(e => e.codigoViaIngreso)
                    .HasName("PK__viaIngre__139B26738392E95A");

                entity.ToTable("viaIngresoServicio");

                entity.Property(e => e.codigoViaIngreso)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.viaIngresoServicio1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("viaIngresoServicio");
            });

            modelBuilder.Entity<voluntadAnticipadum>(entity =>
            {
                entity.HasKey(e => e.idVoluntad)
                    .HasName("PK__voluntad__70E7B7ACEBB2DA36");

                entity.Property(e => e.codigoPrestadorSalud)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.fecha).HasColumnType("date");

                entity.HasOne(d => d.codigoPrestadorSaludNavigation)
                    .WithMany(p => p.voluntadAnticipada)
                    .HasForeignKey(d => d.codigoPrestadorSalud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__voluntadA__codig__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
