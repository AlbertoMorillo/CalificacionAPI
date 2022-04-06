using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Asignatura")]
    public partial class Asignatura
    {
        public Asignatura()
        {
            Calificacions = new HashSet<Calificacion>();
            Horarios = new HashSet<Horario>();
            Seleccions = new HashSet<Seleccion>();
        }

        [Key]
        public int AsignaturaId { get; set; }
        [StringLength(15)]
        public string AsignaturaCod { get; set; }
        [StringLength(70)]
        public string AsignaturaNom { get; set; }

        [InverseProperty(nameof(Calificacion.MateriaNavigation))]
        public virtual ICollection<Calificacion> Calificacions { get; set; }
        [InverseProperty(nameof(Horario.MateriaNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
        [InverseProperty(nameof(Seleccion.MateriaNavigation))]
        public virtual ICollection<Seleccion> Seleccions { get; set; }
    }
}
