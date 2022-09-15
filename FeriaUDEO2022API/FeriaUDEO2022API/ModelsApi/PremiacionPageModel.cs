namespace FeriaUDEO2022API.ModelsApi
{
    public class PremiacionPageModel
    {
        public PodioModel PrimerLugar { get; set; }
        public PodioModel SegundoLugar { get; set; }
        public PodioModel TercerLugar { get; set; }

        public ICollection<ProyectoCardModel> Reconocimientos{ get; set; }

        public ICollection<GanadoresCategoria> GanadoresCategorias { get; set; }

        
    }

    public class PodioModel
    {
        public int idProyecto   { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string categoria { get; set; }
    }

    public class GanadoresCategoria { 
        public string Categoria { get; set; }
        public ICollection<ProyectoCardPremiacionModel> Ganadores { get; set; }
    }

    public class ProyectoCardPremiacionModel:ProyectoCardModel {
        public int votos { get; set; }
    }


}
