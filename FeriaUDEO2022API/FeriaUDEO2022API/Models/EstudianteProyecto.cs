using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class EstudianteProyecto
    {
        public int IdEstudianteProyecto { get; set; }
        public int? IdProyecto { get; set; }
        public int? Carnet { get; set; }

        public virtual Estudiante? CarnetNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
