using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FeriaUDEO2022API.Models
{
    public partial class FeriaUdeo2022Context : DbContext
    {
        public FeriaUdeo2022Context()
        {
        }

        public FeriaUdeo2022Context(DbContextOptions<FeriaUdeo2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carreras { get; set; } = null!;
        public virtual DbSet<CategoriaProyecto> CategoriaProyectos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<EstudianteProyecto> EstudianteProyectos { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Ganador> Ganadors { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<Reconocimiento> Reconocimientos { get; set; } = null!;
        public virtual DbSet<ReconocimientoProyecto> ReconocimientoProyectos { get; set; } = null!;
        public virtual DbSet<SupervisorProyecto> SupervisorProyectos { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<VotoUsuario> VotoUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=N1NWPLSK12SQL-v01.shr.prod.ams1.secureserver.net;Initial Catalog=FeriaUdeo2022;Integrated Security=False;User ID=FeriaUdeoDEV;Password=X93Uwm68UBSLJTs;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__CARRERA__82525F26ED2EF367");

                entity.ToTable("CARRERA");

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CategoriaProyecto>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__CD54BC5A33668F16");

                entity.ToTable("CATEGORIA_PROYECTO");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Carnet)
                    .HasName("PK__ESTUDIAN__4CDEAA6FCDC20164");

                entity.ToTable("ESTUDIANTE");

                entity.Property(e => e.Carnet)
                    .ValueGeneratedNever()
                    .HasColumnName("carnet");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre2");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_carrera");
            });

            modelBuilder.Entity<EstudianteProyecto>(entity =>
            {
                entity.HasKey(e => e.IdEstudianteProyecto)
                    .HasName("PK__ESTUDIAN__F3D63E4E5B64FA55");

                entity.ToTable("ESTUDIANTE_PROYECTO");

                entity.HasIndex(e => new { e.IdProyecto, e.Carnet }, "uc_estudiante_proyecto")
                    .IsUnique();

                entity.Property(e => e.IdEstudianteProyecto).HasColumnName("id_estudiante_proyecto");

                entity.Property(e => e.Carnet).HasColumnName("carnet");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.CarnetNavigation)
                    .WithMany(p => p.EstudianteProyectos)
                    .HasForeignKey(d => d.Carnet)
                    .HasConstraintName("fk_estudiante_proyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.EstudianteProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("fk_proyecto_estudiante");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK__EVENTO__AF150CA584C4AB0A");

                entity.ToTable("EVENTO");

                entity.Property(e => e.IdEvento)
                    .ValueGeneratedNever()
                    .HasColumnName("id_evento");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Ganador>(entity =>
            {
                entity.HasKey(e => e.IdPodio)
                    .HasName("PK__GANADOR__02CACAE36C0AC701");

                entity.ToTable("GANADOR");

                entity.Property(e => e.IdPodio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_podio");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Ganadors)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("fk_proyecto_ganador");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK__PROYECTO__F38AD81D18EA7644");

                entity.ToTable("PROYECTO");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.HoraFin)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_fin");

                entity.Property(e => e.HoraInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_inicio");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.ImgBanner)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("img_banner");

                entity.Property(e => e.ImgCarta)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("img_carta");

                entity.Property(e => e.ImgStandar)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("img_standar");

                entity.Property(e => e.LinkDirecto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("link_directo");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Video)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("video");

                entity.Property(e => e.Votos).HasColumnName("votos");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoria");
            });

            modelBuilder.Entity<Reconocimiento>(entity =>
            {
                entity.HasKey(e => e.IdReconocimiento)
                    .HasName("PK__RECONOCI__28030567EBCF20DB");

                entity.ToTable("RECONOCIMIENTO");

                entity.Property(e => e.IdReconocimiento).HasColumnName("id_reconocimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ReconocimientoProyecto>(entity =>
            {
                entity.HasKey(e => e.IdReconocimientoProyecto)
                    .HasName("PK__RECONOCI__04188E279A60C2B5");

                entity.ToTable("RECONOCIMIENTO_PROYECTO");

                entity.HasIndex(e => new { e.IdProyecto, e.IdReconocimiento }, "uc_proyecto_reconocimiento")
                    .IsUnique();

                entity.Property(e => e.IdReconocimientoProyecto).HasColumnName("id_reconocimiento_proyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.IdReconocimiento).HasColumnName("id_reconocimiento");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.ReconocimientoProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("fk_proyecto_reconocimiento");

                entity.HasOne(d => d.IdReconocimientoNavigation)
                    .WithMany(p => p.ReconocimientoProyectos)
                    .HasForeignKey(d => d.IdReconocimiento)
                    .HasConstraintName("fk_reconocimiento_proyecto");
            });

            modelBuilder.Entity<SupervisorProyecto>(entity =>
            {
                entity.HasKey(e => e.IdSupervisorProyecto)
                    .HasName("PK__SUPERVIS__6FEDE2C3AB02DBD2");

                entity.ToTable("SUPERVISOR_PROYECTO");

                entity.HasIndex(e => new { e.IdProyecto, e.IdUsuario }, "uc_supervisor_proyecto")
                    .IsUnique();

                entity.Property(e => e.IdSupervisorProyecto).HasColumnName("id_supervisor_proyecto");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.SupervisorProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("fk_proyecto_supervisor");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.SupervisorProyectos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_usuario_supervisor");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__B17D78C8B1473EB0");

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__4E3E04AD61EBA24B");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Usuario1, "UQ__USUARIO__9AFF8FC6F9D7B216")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("contrasenia");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Informacion)
                    .HasColumnType("text")
                    .HasColumnName("informacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre2");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo");
            });

            modelBuilder.Entity<VotoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdVotoUsuario)
                    .HasName("PK__VOTO_USU__9BC1F27B22934B13");

                entity.ToTable("VOTO_USUARIO");

                entity.HasIndex(e => new { e.IdProyecto, e.IdUsuario }, "pk_supervisor")
                    .IsUnique();

                entity.Property(e => e.IdVotoUsuario).HasColumnName("id_voto_usuario");

                entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Puntuacion)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("puntuacion");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.VotoUsuarios)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("fk_proyecto_voto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.VotoUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("fk_usuario_voto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
