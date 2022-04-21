using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class GestionCalificacionDBContext : DbContext
    {
        public GestionCalificacionDBContext()
        {
        }

        public GestionCalificacionDBContext(DbContextOptions<GestionCalificacionDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Escuela> Escuelas { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Pensum> Pensums { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }
        public virtual DbSet<Seleccion> Seleccions { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<TiposEmpleado> TiposEmpleados { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Valore> Valores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GestionCalificacionDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.ToTable("Asignatura");

                entity.Property(e => e.AsignaturaCod)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AsignaturaNom)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion);

                entity.ToTable("Calificacion");

                entity.HasIndex(e => new { e.Semestre, e.Matriculan, e.Materia, e.Grupo }, "uq_Calificacion_duplicada")
                    .IsUnique();

                entity.Property(e => e.Codigoprof).HasColumnName("codigoprof");

                entity.Property(e => e.Escuela).HasColumnName("escuela");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Final).HasColumnName("final");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Matriculan)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("matriculan")
                    .IsFixedLength(true);

                entity.Property(e => e.Nl)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("NL");

                entity.Property(e => e.Parcial).HasColumnName("parcial");

                entity.Property(e => e.Pensum).HasColumnName("pensum");

                entity.Property(e => e.Practica).HasColumnName("practica");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Tpractico).HasColumnName("tpractico");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.HasOne(d => d.EscuelaNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Escuela)
                    .HasConstraintName("FK__Calificac__escue__40058253");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK__Calificac__mater__40F9A68C");

                entity.HasOne(d => d.PensumNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Pensum)
                    .HasConstraintName("FK__Calificac__pensu__41EDCAC5");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Semestre)
                    .HasConstraintName("FK__Calificac__semes__42E1EEFE");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK__Calificac__usuar__43D61337");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResetPasswordCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoEmpleadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdTipoEmpleado)
                    .HasConstraintName("FK_Empleados_TiposEmpleados");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Usuarios");
            });

            modelBuilder.Entity<Escuela>(entity =>
            {
                entity.HasKey(e => e.IdEscuela);

                entity.ToTable("Escuela");

                entity.Property(e => e.IdEscuela).ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreLabel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.NombreEmergencia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResetPasswordCode)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmergencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TElefonoEmergencia");

                entity.HasOne(d => d.IdEscuelaNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Escuela");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Usuarios");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorarios);

                entity.ToTable("Horario");

                entity.Property(e => e.Aula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("aula")
                    .IsFixedLength(true);

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Escuela).HasColumnName("escuela");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("estatus")
                    .IsFixedLength(true);

                entity.Property(e => e.Fechahora)
                    .HasColumnType("datetime")
                    .HasColumnName("fechahora");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Grupos).HasColumnName("grupos");

                entity.Property(e => e.He)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("he");

                entity.Property(e => e.Hs)
                    .HasColumnType("numeric(9, 2)")
                    .HasColumnName("hs");

                entity.Property(e => e.Limite).HasColumnName("limite");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Profesor).HasColumnName("profesor");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.HasOne(d => d.EscuelaNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Escuela)
                    .HasConstraintName("FK__Horario__escuela__2B0A656D");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK__Horario__materia__2BFE89A6");

                entity.HasOne(d => d.ProfesorNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Profesor)
                    .HasConstraintName("FK__Horario__profeso__6442E2C9");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Semestre)
                    .HasConstraintName("FK__Horario__semestr__2DE6D218");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK__Horario__usuario__2EDAF651");
            });

            modelBuilder.Entity<Pensum>(entity =>
            {
                entity.HasKey(e => e.IdPensum);

                entity.ToTable("Pensum");

                entity.Property(e => e.Creditos).HasColumnName("creditos");

                entity.Property(e => e.Escuela).HasColumnName("escuela");

                entity.Property(e => e.Materia)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("materia")
                    .IsFixedLength(true);

                entity.Property(e => e.Pensum1).HasColumnName("pensum");

                entity.Property(e => e.Prerequisi)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("prerequisi")
                    .IsFixedLength(true);

                entity.Property(e => e.Semestre).HasColumnName("semestre");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK_Empleado");

                entity.ToTable("Profesor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Profesor_Empleados");
            });

            modelBuilder.Entity<Seleccion>(entity =>
            {
                entity.HasKey(e => e.IdSeleccion);

                entity.ToTable("Seleccion");

                entity.Property(e => e.Escuela).HasColumnName("escuela");

                entity.Property(e => e.Grupo).HasColumnName("grupo");

                entity.Property(e => e.Materia).HasColumnName("materia");

                entity.Property(e => e.Matriculan).HasColumnName("matriculan");

                entity.Property(e => e.Pensum).HasColumnName("pensum");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.HasOne(d => d.EscuelaNavigation)
                    .WithMany(p => p.Seleccions)
                    .HasForeignKey(d => d.Escuela)
                    .HasConstraintName("FK__Seleccion__escue__4E53A1AA");

                entity.HasOne(d => d.MateriaNavigation)
                    .WithMany(p => p.Seleccions)
                    .HasForeignKey(d => d.Materia)
                    .HasConstraintName("FK__Seleccion__mater__503BEA1C");

                entity.HasOne(d => d.MatriculanNavigation)
                    .WithMany(p => p.Seleccions)
                    .HasForeignKey(d => d.Matriculan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Seleccion__matri__4D5F7D71");

                entity.HasOne(d => d.PensumNavigation)
                    .WithMany(p => p.Seleccions)
                    .HasForeignKey(d => d.Pensum)
                    .HasConstraintName("FK__Seleccion__pensu__4F47C5E3");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Seleccions)
                    .HasForeignKey(d => d.Semestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Seleccion__semes__4C6B5938");
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.HasKey(e => e.IdSemestres);

                entity.ToTable("Semestre");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Semestre1).HasColumnName("Semestre");
            });

            modelBuilder.Entity<TiposEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEmpleado);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_TipoUsuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuario");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_TiposUsuarios");
            });

            modelBuilder.Entity<Valore>(entity =>
            {
                entity.HasKey(e => e.IdValores)
                    .HasName("PK__Valores__3214EC270C3BC58A");

                entity.Property(e => e.Created)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("valor3");

                entity.Property(e => e.Valor4)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("valor4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
