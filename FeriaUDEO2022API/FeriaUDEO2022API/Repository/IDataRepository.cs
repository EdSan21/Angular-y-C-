using FeriaUDEO2022API.ModelsApi;
namespace FeriaUDEO2022API.Repository
{
    public interface IDataRepository
    {
        Task<List<JuradoPageModel>> GetjuradoAsync();
        Task<ProyectosPageModel> GetProyectsAsync();

        Task<DetailProyectModel> GetDetailsAsync(int id);
        Task<PremiacionPageModel> GetPremiacionAsync();
        Task<bool> GetEventoVotoAsync();
        Task<int> VerificarVoto(int idProyecto, int idUsuario, string Usuario);
        Task<DetailProyectLoggedModel> GetDetailsLoggedAsync(int id, int idUsuario);

    }
}
