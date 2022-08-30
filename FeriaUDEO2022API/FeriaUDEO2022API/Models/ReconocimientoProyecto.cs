using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class ReconocimientoProyecto
    {
        public int IdReconocimientoProyecto { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdReconocimiento { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Reconocimiento? IdReconocimientoNavigation { get; set; }
    }
}
