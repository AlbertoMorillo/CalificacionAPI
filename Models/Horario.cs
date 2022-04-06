using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Horario")]
    public partial class Horario
    {
        [Column("semestre")]
        public int? Semestre { get; set; }
        [Column("materia")]
        public int? Materia { get; set; }
        [Column("grupo")]
        public int? Grupo { get; set; }
        [Column("tipo")]
        public int? Tipo { get; set; }
        [Column("dia")]
        public int? Dia { get; set; }
        [Column("profesor")]
        public int? Profesor { get; set; }
        [Column("he", TypeName = "numeric(9, 2)")]
        public decimal? He { get; set; }
        [Column("hs", TypeName = "numeric(9, 2)")]
        public decimal? Hs { get; set; }
        [Column("aula")]
        [StringLength(10)]
        public string Aula { get; set; }
        [Column("limite")]
        public int? Limite { get; set; }
        [Column("grupos")]
        public int? Grupos { get; set; }
        [Column("escuela")]
        public int? Escuela { get; set; }
        [Column("fechahora", TypeName = "datetime")]
        public DateTime? Fechahora { get; set; }
        [Column("usuario")]
        public int? Usuario { get; set; }
        [Column("estatus")]
        [StringLength(2)]
        public string Estatus { get; set; }
        [Key]
        public int IdHorarios { get; set; }

        [ForeignKey(nameof(Escuela))]
        [InverseProperty("Horarios")]
        public virtual Escuela EscuelaNavigation { get; set; }
        [ForeignKey(nameof(Materia))]
        [InverseProperty(nameof(Asignatura.Horarios))]
        public virtual Asignatura MateriaNavigation { get; set; }
        [ForeignKey(nameof(Profesor))]
        [InverseProperty("Horarios")]
        public virtual Profesor ProfesorNavigation { get; set; }
        [ForeignKey(nameof(Semestre))]
        [InverseProperty("Horarios")]
        public virtual Semestre SemestreNavigation { get; set; }
        [ForeignKey(nameof(Usuario))]
        [InverseProperty("Horarios")]
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
