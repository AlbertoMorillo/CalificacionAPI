using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Seleccion")]
    public partial class Seleccion
    {
        [Column("semestre")]
        public int Semestre { get; set; }
        [Column("matriculan")]
        public int Matriculan { get; set; }
        [Column("escuela")]
        public int? Escuela { get; set; }
        [Column("pensum")]
        public int? Pensum { get; set; }
        [Column("materia")]
        public int? Materia { get; set; }
        [Column("grupo")]
        public int? Grupo { get; set; }
        [Key]
        public int IdSeleccion { get; set; }

        [ForeignKey(nameof(Escuela))]
        [InverseProperty("Seleccions")]
        public virtual Escuela EscuelaNavigation { get; set; }
        [ForeignKey(nameof(Materia))]
        [InverseProperty(nameof(Asignatura.Seleccions))]
        public virtual Asignatura MateriaNavigation { get; set; }
        [ForeignKey(nameof(Matriculan))]
        [InverseProperty(nameof(Usuario.Seleccions))]
        public virtual Usuario MatriculanNavigation { get; set; }
        [ForeignKey(nameof(Pensum))]
        [InverseProperty("Seleccions")]
        public virtual Pensum PensumNavigation { get; set; }
        [ForeignKey(nameof(Semestre))]
        [InverseProperty("Seleccions")]
        public virtual Semestre SemestreNavigation { get; set; }
    }
}
