using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Reconocimiento
    {
        public Reconocimiento()
        {
            ReconocimientoProyectos = new HashSet<ReconocimientoProyecto>();
        }

        public int IdReconocimiento { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<ReconocimientoProyecto> ReconocimientoProyectos { get; set; }
    }
}
