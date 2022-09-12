using FeriaUDEO2022API.ModelsApi;
using Microsoft.AspNetCore.Mvc;

namespace FeriaUDEO2022API.Repository
{
    public interface ILoginRepository
    {
        Task<ActionResult<string>> LoginAsync(string Cadena);
    }
}
