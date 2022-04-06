using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Calificacion")]
    [Index(nameof(Semestre), nameof(Matriculan), nameof(Materia), nameof(Grupo), Name = "uq_Calificacion_duplicada", IsUnique = true)]
    public partial class Calificacion
    {
        [Column("semestre")]
        public int? Semestre { get; set; }
        [Column("matriculan")]
        [StringLength(18)]
        public string Matriculan { get; set; }
        [Column("escuela")]
        public int? Escuela { get; set; }
        [Column("pensum")]
        public int? Pensum { get; set; }
        [Column("materia")]
        public int? Materia { get; set; }
        [Column("grupo")]
        public int? Grupo { get; set; }
        [Column("tipo")]
        public int? Tipo { get; set; }
        [Column("parcial")]
        public int? Parcial { get; set; }
        [Column("practica")]
        public int? Practica { get; set; }
        [Column("final")]
        public int? Final { get; set; }
        [Column("total")]
        public int? Total { get; set; }
        [Column("estatus")]
        public int? Estatus { get; set; }
        [Column("tpractico")]
        public int? Tpractico { get; set; }
        [Column("usuario")]
        public int? Usuario { get; set; }
        [Column("codigoprof")]
        public int? Codigoprof { get; set; }
        [Key]
        public int IdCalificacion { get; set; }
        [Column("NL")]
        [StringLength(5)]
        public string Nl { get; set; }

        [ForeignKey(nameof(Escuela))]
        [InverseProperty("Calificacions")]
        public virtual Escuela EscuelaNavigation { get; set; }
        [ForeignKey(nameof(Materia))]
        [InverseProperty(nameof(Asignatura.Calificacions))]
        public virtual Asignatura MateriaNavigation { get; set; }
        [ForeignKey(nameof(Pensum))]
        [InverseProperty("Calificacions")]
        public virtual Pensum PensumNavigation { get; set; }
        [ForeignKey(nameof(Semestre))]
        [InverseProperty("Calificacions")]
        public virtual Semestre SemestreNavigation { get; set; }
        [ForeignKey(nameof(Usuario))]
        [InverseProperty("Calificacions")]
        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
