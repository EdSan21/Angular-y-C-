using FeriaUDEO2022API.ModelsApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeriaUDEO2022API.Repository
{
    public class DataRepository:IDataRepository
    {
        private readonly FeriaUDEO2022Context _context;
        public DataRepository(FeriaUDEO2022Context context)
        {
            _context = context;
        }
        public async Task<List<JuradoPageModel>> GetjuradoAsync()
        {

            List<JuradoPageModel> respuesta = await _context.TipoUsuarios.Select(t =>
                new JuradoPageModel { 
                    Tipo=t.Nombre,
                    lista= _context.Usuarios.Where(x=>x.IdTipoUsuario==t.IdTipoUsuario).Select(x=>
                        new JuradoModel { 
                            nombre1=x.Nombre,
                            nobmre2=x.Nombre2,
                            apellido1=x.Apellido,
                            apellido2=x.Apellido2,
                            imagen=x.Imagen,
                            titulo=x.Titulo,
                            informacion=x.Informacion
                        }
                    ).ToList()
                }

            ).ToListAsync();

            return respuesta;
        }

        public async Task<ProyectosPageModel> GetProyectsAsync()
        {

            ProyectosPageModel respuesta = new ProyectosPageModel
            {
                categorias = await _context.CategoriaProyectos.Select(x =>
                        new CategoriasApiModel
                        {
                            idCategoria = x.IdCategoria,
                            nombre = x.Nombre
                        }
                    ).ToListAsync(),

                emision = await _context.Proyectos.Where(x => x.HoraFin >= DateTime.Now && x.HoraInicio <= DateTime.Now)
                    .Select(x =>
                        new ProyectoCardModel {
                            idProyecto = x.IdProyecto,
                            categoria = x.IdCategoriaNavigation.Nombre,
                            titulo = x.Titulo,
                            descripcion = x.Descripcion,
                            imgCarta = x.ImgCarta,
                            idcategoria=x.IdCategoria
                        }
                    ).ToListAsync(),

                proyectos = await _context.Proyectos.Select(x =>
                        new ProyectoCardModel
                        {
                            idProyecto = x.IdProyecto,
                            categoria = x.IdCategoriaNavigation.Nombre,
                            titulo = x.Titulo,
                            descripcion = x.Descripcion,
                            imgCarta = x.ImgCarta,
                            idcategoria = x.IdCategoria
                        }
                    ).ToListAsync()
            };

            return respuesta;
        }

    }
}
