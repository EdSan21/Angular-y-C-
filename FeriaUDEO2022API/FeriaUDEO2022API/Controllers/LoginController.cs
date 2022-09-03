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

        private readonly FeriaUDEO2022Context _context;
        private readonly ILoginRepository _loginRepository;
        public LoginController( ILoginRepository dataRepository, FeriaUDEO2022Context context)
        {
            _loginRepository = dataRepository;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SessionModel>> PostTipoUsuario(LoginModel Login)
        {
            if (_context.TipoUsuarios == null)
            {
                return Problem("Entity set 'FeriaUDEO2022Context.TipoUsuarios'  is null.");
            }
            var respuesta = await _loginRepository.LoginAsync(Login.User,Login.Password);

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
