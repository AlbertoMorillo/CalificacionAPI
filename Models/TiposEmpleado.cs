using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    public partial class TiposEmpleado
    {
        public TiposEmpleado()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        public int IdTipoEmpleado { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Empleado.IdTipoEmpleadoNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
