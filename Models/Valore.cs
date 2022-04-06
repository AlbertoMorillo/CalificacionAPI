using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class Valore
    {
        [Key]
        public int IdValores { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Created { get; set; }
        [StringLength(50)]
        public string Tipo { get; set; }
        [StringLength(50)]
        public string Valor { get; set; }
        [StringLength(50)]
        public string Valor2 { get; set; }
        public int? Padre { get; set; }
        [Column("valor3")]
        [StringLength(50)]
        public string Valor3 { get; set; }
        [Column("valor4")]
        [StringLength(500)]
        public string Valor4 { get; set; }
    }
}
