using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalificacionAPI.Models
{
    public partial class spes_CalificacionEstudiante_Result
    {
        public int semestre { get; set; }
        public string matricula { get; set; }
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public Nullable<decimal> escuela { get; set; }
        public Nullable<decimal> pensum { get; set; }
        public string materia { get; set; }
        public Nullable<int> grupo { get; set; }
        public string NL { get; set; }
        public Nullable<int> tpractico { get; set; }
        public Nullable<int> parcial { get; set; }
        public Nullable<int> final { get; set; }
        public Nullable<int> total { get; set; }
    }
}
