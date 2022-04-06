using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Escuela")]
    public partial class Escuela
    {
        public Escuela()
        {
            Calificacions = new HashSet<Calificacion>();
            Estudiantes = new HashSet<Estudiante>();
            Horarios = new HashSet<Horario>();
            Seleccions = new HashSet<Seleccion>();
        }

        [Key]
        public int IdEscuela { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Titulo { get; set; }
        [StringLength(50)]
        public string NombreLabel { get; set; }
        public int? Mostrar { get; set; }

        [InverseProperty(nameof(Calificacion.EscuelaNavigation))]
        public virtual ICollection<Calificacion> Calificacions { get; set; }
        [InverseProperty(nameof(Estudiante.IdEscuelaNavigation))]
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        [InverseProperty(nameof(Horario.EscuelaNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
        [InverseProperty(nameof(Seleccion.EscuelaNavigation))]
        public virtual ICollection<Seleccion> Seleccions { get; set; }
    }
}
