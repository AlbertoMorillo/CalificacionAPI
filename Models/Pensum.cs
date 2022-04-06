using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Pensum")]
    public partial class Pensum
    {
        public Pensum()
        {
            Calificacions = new HashSet<Calificacion>();
            Seleccions = new HashSet<Seleccion>();
        }

        [Column("escuela")]
        public int? Escuela { get; set; }
        [Column("pensum")]
        public int? Pensum1 { get; set; }
        [Column("materia")]
        [StringLength(15)]
        public string Materia { get; set; }
        [Column("prerequisi")]
        [StringLength(12)]
        public string Prerequisi { get; set; }
        [Column("creditos")]
        public int? Creditos { get; set; }
        [Column("semestre")]
        public int? Semestre { get; set; }
        [Key]
        public int IdPensum { get; set; }

        [InverseProperty(nameof(Calificacion.PensumNavigation))]
        public virtual ICollection<Calificacion> Calificacions { get; set; }
        [InverseProperty(nameof(Seleccion.PensumNavigation))]
        public virtual ICollection<Seleccion> Seleccions { get; set; }
    }
}
