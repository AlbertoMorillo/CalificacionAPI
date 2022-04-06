using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificacions = new HashSet<Calificacion>();
            Empleados = new HashSet<Empleado>();
            Estudiantes = new HashSet<Estudiante>();
            Horarios = new HashSet<Horario>();
            Seleccions = new HashSet<Seleccion>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [Column("Usuario")]
        [StringLength(50)]
        public string Usuario1 { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? Bloqueo { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(TiposUsuario.Usuarios))]
        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty(nameof(Calificacion.UsuarioNavigation))]
        public virtual ICollection<Calificacion> Calificacions { get; set; }
        [InverseProperty(nameof(Empleado.IdUsuarioNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
        [InverseProperty(nameof(Estudiante.IdUsuarioNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        [InverseProperty(nameof(Horario.UsuarioNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
        [InverseProperty(nameof(Seleccion.MatriculanNavigation))]
        public virtual ICollection<Seleccion> Seleccions { get; set; }
    }
}
