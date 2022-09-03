using FeriaUDEO2022API.ModelsApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeriaUDEO2022API.Models;

namespace FeriaUDEO2022API.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly FeriaUDEO2022Context _context;
        public LoginRepository(FeriaUDEO2022Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<SessionModel>> LoginAsync(string User, string Password)
        {

            SessionModel session = await _context.Usuarios.Where(x => EF.Functions.Collate(x.Usuario1, "SQL_Latin1_General_CP1_CS_AS") == User && EF.Functions.Collate(x.Contrasenia, "SQL_Latin1_General_CP1_CS_AS")==Password).
                Select(X=> new SessionModel { 
                    SessionUser=X.Usuario1,
                    SessionId=X.IdUsuario,
                    SessionName=X.Nombre+" "+X.Apellido,
                    SessionImg=X.Imagen
                }).FirstOrDefaultAsync() ;

            if (session==null)
            {
                return null;
            }
            else
            {
                return session;
            }
            
        }
    }
}
