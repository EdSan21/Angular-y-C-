using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Ganador
    {
        public int IdPodio { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
