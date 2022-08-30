namespace FeriaUDEO2022API.ModelsApi
{
    public class ProyectoCardModel
    {
        public int idProyecto{ get; set; }
        public string titulo{ get; set; }
        public string descripcion{ get; set; }
        public string imgCarta{ get; set; }
        public string categoria  { get; set; }
        public int idcategoria { get; set; }

    }
    public class CategoriasApiModel
    {
        public int idCategoria { get; set; }
        public string nombre { get; set; }

    }


    public class ProyectosPageModel {
        public IEnumerable<CategoriasApiModel> categorias{ get; set; }
        public IEnumerable<ProyectoCardModel> emision { get; set; }
        public IEnumerable<ProyectoCardModel> proyectos { get; set; }

    }
}
