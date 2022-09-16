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

            List<JuradoPageModel> respuesta = await _context.TipoUsuarios.Where(x=>x.IdTipoUsuario!=2).Select(t =>
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
                            descripcion = x.Descripcion.Substring(0, 100) + "...",
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
                            descripcion = x.Descripcion.Substring(0,100)+"...",
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
                categoria=x.IdCategoriaNavigation.Nombre,
                directo=x.LinkDirecto,
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

        public async Task<DetailProyectLoggedModel> GetDetailsLoggedAsync(int id, int idUsuario)
        {

            DetailProyectLoggedModel respuesta = await _context.Proyectos.Where(x => x.IdProyecto == id).Select(x => new DetailProyectLoggedModel
            {
                titulo = x.Titulo,
                descripcion = x.Descripcion,
                categoria = x.IdCategoriaNavigation.Nombre,
                directo = x.LinkDirecto,
                video = x.Video,
                imgBanner = x.ImgBanner,
                imgCarta = x.ImgCarta,
                imgStandar = x.ImgStandar,
                horaInicio = x.HoraInicio.TimeOfDay.ToString(),
                horaFin = x.HoraFin.TimeOfDay.ToString(),
                estudiantes = _context.EstudianteProyectos.Where(z => z.IdProyecto == id).Select(z => new DetailEstudiantesModel
                {
                    carnet = z.CarnetNavigation.Carnet,
                    nombre = Regex.Replace(z.CarnetNavigation.Nombre + ' ' + z.CarnetNavigation.Nombre2 + ' ' + z.CarnetNavigation.Apellido + ' ' + z.CarnetNavigation.Apellido2, @"\s+", " "),
                    rol = z.CarnetNavigation.Rol,
                    carrera = z.CarnetNavigation.IdCarreraNavigation.Nombre,
                    imagen = z.CarnetNavigation.Imagen
                }).ToList(),
                supervisores = _context.SupervisorProyectos.Where(y => y.IdProyecto == id).Select(y => new DetailSupervisorModel
                {
                    titulo = y.IdUsuarioNavigation.Titulo,
                    informacion = y.IdUsuarioNavigation.Informacion,
                    nombre = Regex.Replace(y.IdUsuarioNavigation.Nombre + ' ' + y.IdUsuarioNavigation.Nombre2 + ' ' + y.IdUsuarioNavigation.Apellido + ' ' + y.IdUsuarioNavigation.Apellido2, @"\s+", " "),
                    imagen = y.IdUsuarioNavigation.Imagen
                }).ToList()





            }).FirstOrDefaultAsync();

            return respuesta;


        }

        public async Task<PremiacionPageModel> GetPremiacionAsync()
        {

            PremiacionPageModel respuesta = new PremiacionPageModel
            {
                PrimerLugar = await _context.Ganadors.Where(x => x.IdPodio == 1).Select(x => new PodioModel {
                    idProyecto = x.IdProyectoNavigation.IdProyecto,
                    Titulo=x.IdProyectoNavigation.Titulo,
                    categoria=x.IdProyectoNavigation.IdCategoriaNavigation.Nombre,
                    Imagen=x.IdProyectoNavigation.ImgStandar
                }).FirstOrDefaultAsync(),
                SegundoLugar = await _context.Ganadors.Where(x => x.IdPodio == 1).Select(x => new PodioModel
                {
                    idProyecto = x.IdProyectoNavigation.IdProyecto,
                    Titulo = x.IdProyectoNavigation.Titulo,
                    categoria = x.IdProyectoNavigation.IdCategoriaNavigation.Nombre,
                    Imagen = x.IdProyectoNavigation.ImgStandar
                }).FirstOrDefaultAsync(),
                TercerLugar = await _context.Ganadors.Where(x => x.IdPodio == 1).Select(x => new PodioModel
                {
                    idProyecto = x.IdProyectoNavigation.IdProyecto,
                    Titulo = x.IdProyectoNavigation.Titulo,
                    categoria = x.IdProyectoNavigation.IdCategoriaNavigation.Nombre,
                    Imagen = x.IdProyectoNavigation.ImgStandar
                }).FirstOrDefaultAsync(),

                Reconocimientos= await _context.ReconocimientoProyectos.Select(x=> new ProyectoCardModel {
                    idProyecto = x.IdProyectoNavigation.IdProyecto,
                    categoria = x.IdProyectoNavigation.IdCategoriaNavigation.Nombre,
                    titulo = x.IdProyectoNavigation.Titulo,
                    descripcion = x.IdReconocimientoNavigation.Descripcion,
                    imgCarta = x.IdProyectoNavigation.ImgCarta,
                    idcategoria = x.IdProyectoNavigation.IdCategoria
                }).ToListAsync(),

                GanadoresCategorias = await _context.CategoriaProyectos.Select(x=>new GanadoresCategoria { 
                    Categoria=x.Nombre,
                    Ganadores=_context.Proyectos.Where(z=> z.IdCategoria==x.IdCategoria).Select(z=> new ProyectoCardPremiacionModel {
                        idProyecto = z.IdProyecto,
                        categoria = z.IdCategoriaNavigation.Nombre,
                        titulo = z.Titulo,
                        descripcion = z.Descripcion,
                        imgCarta = z.ImgCarta,
                        idcategoria = z.IdCategoria,
                        votos=z.Votos
                    }).OrderByDescending(z=>z.votos).Take(3).ToList()
                    
                }).ToListAsync()

            };


            return respuesta;
        }

        public async Task<bool> GetEventoVotoAsync()
        {

            Evento evento = await _context.Eventos.FindAsync(1);
            bool respuesta = evento.Activo;

            return respuesta;
        }

        public async Task<int> VerificarVoto(int idProyecto, int idUsuario, string Usuario)
        {
            if (_context.Usuarios.Where(x => x.IdUsuario == idUsuario && EF.Functions.Collate(x.Usuario1, "SQL_Latin1_General_CP1_CS_AS") == Usuario).FirstOrDefault() != null)
            {
                VotoUsuario voto = await _context.VotoUsuarios.Where(x => x.IdUsuario == idUsuario && x.IdProyecto == idProyecto).FirstOrDefaultAsync();
                if (voto==null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(voto.Puntuacion);
                }



                
            }
            else {
                return 404;
            }
        }


    }
}
