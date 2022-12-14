using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using SistemaCompra.DAL.Interfaces;
using SitemaCompraTaller.BLL.Interfaces;
using SistemWebTaller.Entity;
using SistemaCompra.DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace SitemaCompraTaller.BLL.Implementacion
{
    public class CorreoService :ICorreoService
    {

        private readonly IGenericRepository<Configuracion> _repositorio;
        public CorreoService( IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;

        }

        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);
                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], Config["clave"]),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true,


                };

                correo.To.Add(new MailAddress(CorreoDestino));

                var clienteservidor = new SmtpClient()
                {
                    Host = (Config["Host"]),
                    Port = int.Parse(Config["Puerto"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                };
                clienteservidor.Send(correo);

                return true;

            }


            catch
            {
                return false;
            }
        }

       
    }
           
        

    
}
