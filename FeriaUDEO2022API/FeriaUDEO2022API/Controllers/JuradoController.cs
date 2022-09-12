using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FeriaUDEO2022API.Models;
using FeriaUDEO2022API.ModelsApi;
using System.Text.Json;
using FeriaUDEO2022API.Repository;

namespace FeriaUDEO2022API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuradoController : ControllerBase
    {
        private readonly FeriaUdeo2022Context _context;
        private readonly IDataRepository _dataRepository;
        public JuradoController(FeriaUdeo2022Context context, IDataRepository dataRepository)
        {
            _context = context;
            _dataRepository = dataRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetjuradoPageAsync()
        {
            if (_context.TipoUsuarios == null)
            {
                return NotFound();
            }
            var respuesta = await _dataRepository.GetjuradoAsync();
            return Ok(respuesta);
        }

    }
}
