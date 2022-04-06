using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
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
                entity.Property(e => e.AsignaturaCod).IsUnicode(false);

                entity.Property(e => e.AsignaturaNom).IsUnicode(false);
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.Property(e => e.Matriculan)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nl).IsUnicode(false);

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
                entity.Property(e => e.Celular).IsUnicode(false);

                entity.Property(e => e.CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.PrimerApellido).IsUnicode(false);

                entity.Property(e => e.PrimerNombre).IsUnicode(false);

                entity.Property(e => e.ResetPasswordCode).IsUnicode(false);

                entity.Property(e => e.SegundoApellido).IsUnicode(false);

                entity.Property(e => e.SegundoNombre).IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono).IsUnicode(false);

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
                entity.Property(e => e.IdEscuela).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.NombreLabel).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Celular).IsUnicode(false);

                entity.Property(e => e.CorreoElectronico).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.NombreEmergencia).IsUnicode(false);

                entity.Property(e => e.PrimerApellido).IsUnicode(false);

                entity.Property(e => e.PrimerNombre).IsUnicode(false);

                entity.Property(e => e.ResetPasswordCode).IsUnicode(false);

                entity.Property(e => e.SegundoApellido).IsUnicode(false);

                entity.Property(e => e.SegundoNombre).IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.TelefonoEmergencia).IsUnicode(false);

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
                entity.Property(e => e.Aula)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Estatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

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
                    .HasConstraintName("FK__Horario__profeso__2CF2ADDF");

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
                entity.Property(e => e.Materia)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Prerequisi)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK_Empleado");

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Profesor_Empleados");
            });

            modelBuilder.Entity<Seleccion>(entity =>
            {
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
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<TiposEmpleado>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_TipoUsuario");

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_Usuario");

                entity.Property(e => e.Usuario1).IsUnicode(false);

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

                entity.Property(e => e.Created).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tipo).IsUnicode(false);

                entity.Property(e => e.Valor).IsUnicode(false);

                entity.Property(e => e.Valor2).IsUnicode(false);

                entity.Property(e => e.Valor3).IsUnicode(false);

                entity.Property(e => e.Valor4).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
