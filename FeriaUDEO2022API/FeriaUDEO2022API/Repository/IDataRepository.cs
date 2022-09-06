using FeriaUDEO2022API.ModelsApi;
namespace FeriaUDEO2022API.Repository
{
    public interface IDataRepository
    {
        Task<List<JuradoPageModel>> GetjuradoAsync();
        Task<ProyectosPageModel> GetProyectsAsync();

        Task<DetailProyectModel> GetDetailsAsync(int id);
    }
}
