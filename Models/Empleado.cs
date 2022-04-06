using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Profesors = new HashSet<Profesor>();
        }

        [Key]
        public int IdEmpleado { get; set; }
        public int IdUsuario { get; set; }
        public int? IdEstadoCivil { get; set; }
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
        public int? IdTipoEmpleado { get; set; }

        [ForeignKey(nameof(IdTipoEmpleado))]
        [InverseProperty(nameof(TiposEmpleado.Empleados))]
        public virtual TiposEmpleado IdTipoEmpleadoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Empleados))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [InverseProperty(nameof(Profesor.IdEmpleadoNavigation))]
        public virtual ICollection<Profesor> Profesors { get; set; }
    }
}
