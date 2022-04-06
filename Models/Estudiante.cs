using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public int IdUsuario { get; set; }
        public int IdEscuela { get; set; }
        [Required]
        [StringLength(50)]
        public string PrimerNombre { get; set; }
        [StringLength(50)]
        public string SegundoNombre { get; set; }
        [Required]
        [StringLength(50)]
        public string PrimerApellido { get; set; }
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string Celular { get; set; }
        [StringLength(50)]
        public string CorreoElectronico { get; set; }
        [StringLength(150)]
        public string ResetPasswordCode { get; set; }
        [StringLength(100)]
        public string NombreEmergencia { get; set; }
        [Column("TElefonoEmergencia")]
        [StringLength(50)]
        public string TelefonoEmergencia { get; set; }

        [ForeignKey(nameof(IdEscuela))]
        [InverseProperty(nameof(Escuela.Estudiantes))]
        public virtual Escuela IdEscuelaNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Estudiantes))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
