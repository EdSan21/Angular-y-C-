using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            EstudianteProyectos = new HashSet<EstudianteProyecto>();
            ReconocimientoProyectos = new HashSet<ReconocimientoProyecto>();
            SupervisorProyectos = new HashSet<SupervisorProyecto>();
            VotoUsuarios = new HashSet<VotoUsuario>();
        }

        public int IdProyecto { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int IdCategoria { get; set; }
        public string Video { get; set; } = null!;
        public string ImgStandar { get; set; } = null!;
        public string ImgCarta { get; set; } = null!;
        public string ImgBanner { get; set; } = null!;
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int Votos { get; set; }

        public virtual CategoriaProyecto IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<EstudianteProyecto> EstudianteProyectos { get; set; }
        public virtual ICollection<ReconocimientoProyecto> ReconocimientoProyectos { get; set; }
        public virtual ICollection<SupervisorProyecto> SupervisorProyectos { get; set; }
        public virtual ICollection<VotoUsuario> VotoUsuarios { get; set; }
    }
}
