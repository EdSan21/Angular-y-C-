using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdCarrera { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
