using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CalificacionAPI.Models
{
    [Table("Profesor")]
    public partial class Profesor
    {
        public Profesor()
        {
            Horarios = new HashSet<Horario>();
        }

        [Key]
        public int IdProfesor { get; set; }
        public int? Codigo { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        public int? IdEmpleado { get; set; }

        [ForeignKey(nameof(IdEmpleado))]
        [InverseProperty(nameof(Empleado.Profesors))]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        [InverseProperty(nameof(Horario.ProfesorNavigation))]
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
