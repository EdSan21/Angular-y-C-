﻿using Microsoft.AspNetCore.Mvc;
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
    public class ProyectsController : ControllerBase
    {
        private readonly FeriaUdeo2022Context _context;
        private readonly IDataRepository _dataRepository;

        public ProyectsController(FeriaUdeo2022Context context, IDataRepository dataRepository)
        {
            _context = context;
            _dataRepository = dataRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetProyectsPageAsync()
        {
            if (_context.Proyectos == null)
            {
                return NotFound();
            }
            var respuesta = await _dataRepository.GetProyectsAsync();
            return Ok(respuesta);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProyectsPageAsync([FromRoute] int id)
        {
            var respuesta = await _dataRepository.GetDetailsAsync(id);
            if (respuesta==null)
            {
                return NotFound();
            }
            return Ok(respuesta);
        }

        [Route("lg/{id}")]
        [HttpPost]
        public async Task<IActionResult> GetProyectsLoggedPageAsync([FromRoute] int id, [FromBody] SessionReqModel User)
        {
            var verificador = await _dataRepository.VerificarVoto(id, User.SessionId, User.SessionUser);
            
            if (verificador==404)
            {
                return Unauthorized();
            }
            else
            {
                var respuesta = await _dataRepository.GetDetailsLoggedAsync(id, User.SessionId);
                if (respuesta == null)
                {
                    return NotFound();
                }
                respuesta.voto = verificador;
                respuesta.votacion = await _dataRepository.GetEventoVotoAsync();
                return Ok(respuesta);
            }
        }
    }
}
