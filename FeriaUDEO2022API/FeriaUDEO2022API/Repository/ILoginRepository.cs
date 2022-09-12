using FeriaUDEO2022API.ModelsApi;
using Microsoft.AspNetCore.Mvc;

namespace FeriaUDEO2022API.Repository
{
    public interface ILoginRepository
    {
        Task<ActionResult<SessionModel>> LoginAsync(string Usuario,string Password);
    }
}
