using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCompra.DAL.Interfaces;
using SitemaCompraTaller.BLL.Interfaces;
using SistemWebTaller.Entity;
using SistemaCompra.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Firebase.Auth;
using Newtonsoft.Json.Linq;
using Firebase.Storage;

namespace SitemaCompraTaller.BLL.Implementacion
{
    public class FireBaseServicio : IfirebaseServices
    {
        private readonly IGenericRepository<Configuracion> _repositorio;
        public FireBaseServicio(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;

        }

       

        public async Task<string> SubirStorage(Stream StreamsActivo, string CarpetaDestino, string NombreActivo)
        {
            string UrlImagen = "";
            try
            {

            
               IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

               Dictionary<string, string> Config = query.ToDictionary(keySelector: c=> c.Propiedad, elementSelector: c => c.Valor);
             

                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api _key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"],(Config["clave"]));
                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(

                     Config["ruta"],
                     new FirebaseStorageOptions
                     {
                         AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                         ThrowOnCancel = true

                     })

                    .Child(Config[CarpetaDestino])
                     .Child(Config[NombreActivo])
                     .PutAsync(StreamsActivo, cancellation.Token);
                 UrlImagen = await task;
            }


            catch
            {
                UrlImagen = "";

            }



            return UrlImagen;

        }

    

        public async Task<bool> EliminarStorage(string CarpetaDestino, string NombreActivo)
        {
            try
            {


                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);


                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api _key"]));
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], (Config["clave"]));
                var cancellation = new CancellationTokenSource();

                var task = new FirebaseStorage(

                     Config["ruta"],
                     new FirebaseStorageOptions
                     {
                         AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                         ThrowOnCancel = true

                     })

                    .Child(Config[CarpetaDestino])
                     .Child(Config[NombreActivo])
                     .DeleteAsync();
                 await task;
                return true;
            }
            catch
            {
                return false;

            }

        }

    }
}
