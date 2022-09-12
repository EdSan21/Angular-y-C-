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
    public class LoginController : ControllerBase
    {

        private readonly FeriaUdeo2022Context _context;
        private readonly ILoginRepository _loginRepository;
        public LoginController( ILoginRepository dataRepository, FeriaUdeo2022Context context)
        {
            _loginRepository = dataRepository;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostLogin([FromBody] string Cadena)
        {
            if (_context.TipoUsuarios == null)
            {
                return Problem("Entity set 'FeriaUDEO2022Context.TipoUsuarios'  is null.");
            }
            var respuesta = await _loginRepository.LoginAsync(Cadena);

            if (respuesta==null)
            {
                return NotFound();
            }
            else
            {
                return respuesta;
            }

            
        }



    }
}
