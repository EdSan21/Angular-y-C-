using System;
using System.Collections.Generic;

namespace FeriaUDEO2022API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            SupervisorProyectos = new HashSet<SupervisorProyecto>();
            VotoUsuarios = new HashSet<VotoUsuario>();
        }

        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public int IdTipoUsuario { get; set; }
        public string Titulo { get; set; } = null!;
        public string Informacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Nombre2 { get; set; }
        public string Apellido { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string Imagen { get; set; } = null!;

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<SupervisorProyecto> SupervisorProyectos { get; set; }
        public virtual ICollection<VotoUsuario> VotoUsuarios { get; set; }
    }
}
