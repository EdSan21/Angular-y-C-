using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteProyectos = new HashSet<EstudianteProyecto>();
        }

        public int Carnet { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Nombre2 { get; set; }
        public string Apellido { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public int IdCarrera { get; set; }
        public string Imagen { get; set; } = null!;

        public virtual Carrera IdCarreraNavigation { get; set; } = null!;
        public virtual ICollection<EstudianteProyecto> EstudianteProyectos { get; set; }
    }
}
