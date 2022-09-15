using FeriaUDEO2022API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeriaUDEO2022API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiacionController : ControllerBase
    {
        private readonly FeriaUdeo2022Context _context;
        private readonly IDataRepository _dataRepository;
        public PremiacionController(FeriaUdeo2022Context context, IDataRepository dataRepository)
        {
            _context = context;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPremiacionPageAsync()
        {
            var evento = await _dataRepository.GetEventoVotoAsync();

            if (evento == false)
            {
                return Unauthorized();
            }

            var respuesta = await _dataRepository.GetPremiacionAsync();
            return Ok(respuesta);
        }
    }
}
