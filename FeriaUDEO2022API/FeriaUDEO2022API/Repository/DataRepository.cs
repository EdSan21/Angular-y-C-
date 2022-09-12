using FeriaUDEO2022API.ModelsApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeriaUDEO2022API.Repository
{
    public class DataRepository:IDataRepository
    {
        private readonly FeriaUdeo2022Context _context;
        public DataRepository(FeriaUdeo2022Context context)
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

        public async Task<DetailProyectModel> GetDetailsAsync(int id)
        {

            DetailProyectModel respuesta = await _context.Proyectos.Where(x => x.IdProyecto == id).Select(x => new DetailProyectModel
            {
                titulo = x.Titulo,
                descripcion = x.Descripcion,
                video = x.Video,
                imgBanner=x.ImgBanner,
                imgCarta=x.ImgCarta,
                imgStandar=x.ImgStandar,
                horaInicio=x.HoraInicio.TimeOfDay.ToString(),
                horaFin=x.HoraFin.TimeOfDay.ToString(),
                estudiantes=_context.EstudianteProyectos.Where(z=> z.IdProyecto==id).Select(z=> new DetailEstudiantesModel {
                    carnet=z.CarnetNavigation.Carnet,
                    nombre= Regex.Replace(z.CarnetNavigation.Nombre + ' ' + z.CarnetNavigation.Nombre2 + ' ' + z.CarnetNavigation.Apellido + ' ' + z.CarnetNavigation.Apellido2, @"\s+", " "),
                    rol=z.CarnetNavigation.Rol,
                    carrera=z.CarnetNavigation.IdCarreraNavigation.Nombre,
                    imagen=z.CarnetNavigation.Imagen 
                }).ToList(),
                supervisores=_context.SupervisorProyectos.Where(y=>y.IdProyecto==id).Select(y=> new DetailSupervisorModel { 
                    titulo=y.IdUsuarioNavigation.Titulo,
                    informacion=y.IdUsuarioNavigation.Informacion,
                    nombre= Regex.Replace(y.IdUsuarioNavigation.Nombre + ' ' + y.IdUsuarioNavigation.Nombre2 + ' ' + y.IdUsuarioNavigation.Apellido + ' ' + y.IdUsuarioNavigation.Apellido2, @"\s+", " "),
                    imagen=y.IdUsuarioNavigation.Imagen
                }).ToList()



            }).FirstOrDefaultAsync();

            return respuesta;
        }

    }
}
