namespace FeriaUDEO2022API.ModelsApi
{
    public class JuradoPageModel
    {
        public string Tipo { get; set; }
        public IEnumerable<JuradoModel> lista { get; set; }
    }
    public class JuradoModel {
        public string nombre1 { get; set; }
        public string? nobmre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string imagen { get; set; }
        public string titulo { get; set; }
        public string informacion{ get; set; }

    }
}
