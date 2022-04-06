using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Semestre")]
    public partial class Semestre
    {
        public Semestre()
        {
            Calificacions = new HashSet<Calificacion>();
            Horarios = new HashSet<Horario>();
            Seleccions = new HashSet<Seleccion>();
        }

        [Key]
        public int IdSemestres { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        [Column("Semestre")]
        public int? Semestre1 { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty(nameof(Calificacion.SemestreNavigation))]
        public virtual ICollection<Calificacion> Calificacions { get; set; }
        [InverseProperty(nameof(Horario.SemestreNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
        [InverseProperty(nameof(Seleccion.SemestreNavigation))]
        public virtual ICollection<Seleccion> Seleccions { get; set; }
    }
}
