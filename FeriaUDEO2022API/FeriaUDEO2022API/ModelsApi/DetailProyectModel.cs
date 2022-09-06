namespace FeriaUDEO2022API.ModelsApi
{
    public class DetailProyectModel
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string video { get; set; }
        public string imgStandar { get; set; }
        public string imgCarta { get; set; }
        public string imgBanner { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public ICollection<DetailEstudiantesModel> estudiantes { get; set; }
        public ICollection<DetailSupervisorModel> supervisores { get; set; }
    }

    public class DetailEstudiantesModel { 
        public int carnet { get; set; }
        public string nombre { get; set; }
        public string rol { get; set; }
        public string carrera { get; set; }
        public string imagen { get; set; }
    }

    public class DetailSupervisorModel { 
        public string titulo  { get; set; }
        public string informacion  { get; set; }
        public string nombre  { get; set; }
        public string imagen  { get; set; }

    }

}


