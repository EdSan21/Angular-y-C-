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
using Newtonsoft.Json;

namespace FeriaUDEO2022API.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly FeriaUdeo2022Context _context;
        private readonly EncryptRepository _Encrypt = new EncryptRepository();
        public LoginRepository(FeriaUdeo2022Context context)
        {
            _context = context;
        }

        public async Task<ActionResult<string>> LoginAsync(string cadena)
        {
            try
            {

                string decodificado = _Encrypt.Decrypt(cadena.Trim());

                var Cuenta = JsonConvert.DeserializeObject<LoginModel>(decodificado);

                if (Cuenta==null)
                {
                    return null;
                }

                SessionModel session = await _context.Usuarios.Where(x => EF.Functions.Collate(x.Usuario1, "SQL_Latin1_General_CP1_CS_AS") == Cuenta.User && EF.Functions.Collate(x.Contrasenia, "SQL_Latin1_General_CP1_CS_AS") == Cuenta.Password).
                    Select(X => new SessionModel
                    {
                        SessionUser = X.Usuario1,
                        SessionId = X.IdUsuario,
                        SessionName = X.Nombre + " " + X.Apellido,
                        SessionImg = X.Imagen
                    }).FirstOrDefaultAsync();

                if (session == null)
                {
                    return null;
                }
                else
                {

                    string json = JsonConvert.SerializeObject(session);
                    string respuesta = _Encrypt.Encrypt(json);
                    return respuesta;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
