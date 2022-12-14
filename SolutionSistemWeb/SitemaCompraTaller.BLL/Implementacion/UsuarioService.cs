using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Net;
using SistemaCompra.DAL.Interfaces;
using SitemaCompraTaller.BLL.Interfaces;
using SistemWebTaller.Entity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace SitemaCompraTaller.BLL.Implementacion
{
    public class UsuarioService 
    {
       // private readonly IGenericRepository<Usuario> _repositorio;
       // private readonly IfirebaseServices _firebaserepositorio;
       // private readonly IUtilidadesService _Utilidadrepositorio;
       // private readonly ICorreoService _Correorepositorio;
       // public UsuarioService(


       //IGenericRepository<Usuario> repositorio,
       //IfirebaseServices firebaserepositorio,
       //IUtilidadesService Utilidadrepositorio,
       // ICorreoService Correorepositorio
       //     )
       // {
       //     _repositorio = repositorio;
       //     _firebaserepositorio = firebaserepositorio;
       //     _Utilidadrepositorio = Utilidadrepositorio;
       //     _Correorepositorio = Correorepositorio;
       // }
       // public async Task<string> Lista()
       // {
       //     IQueryable<Usuario> query=await _repositorio.Consultar();
       //    return query.Include(r => r.IdRolNavigation).ToList();

       // }
       

       // public async Task<Usuario> Crear(Usuario entidad, Stream Foto = null, string NombreFoto = "", string UrlPlantillaCorreo = "")
       // {
       //     Usuario usuario_existe = await _repositorio.Obtener(u => u.Correo == entidad.Correo);

       //     if (usuario_existe != null)
       //     {
       //         throw new TaskCanceledException("El correo existente");


       //     }
       //     try
       //     {
       //         string clave_generada = _Utilidadrepositorio.GenerarClave();
       //         entidad.Clave=_Utilidadrepositorio.ConvertiSha256(clave_generada);
       //         entidad.NombreFoto = NombreFoto;

       //         if (Foto!=null)
       //         {
       //             string urlFoto = await _firebaserepositorio.SubirStorage(Foto, "carpeta_usuario", NombreFoto);
       //             entidad.UrlFoto= urlFoto;
       //         }

       //         Usuario usuario_creado = await _repositorio.Crear(entidad);
       //         if(usuario_creado.IdUsuario==0)
                
       //             throw new TaskCanceledException("No se pudo crear el usuario");

       //             if (UrlPlantillaCorreo != "")
       //             {
       //                 UrlPlantillaCorreo = UrlPlantillaCorreo.Replace("[correo]", usuario_creado.Correo).Replace("[clave]", clave_generada);

       //                 string htmlCorreo = "";
       //                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlPlantillaCorreo);
       //                 HttpWebRequest response = (HttpWebRequest)request.GetResponse();

       //                 if (response.StatusCode==HttpStatusCode.OK)
       //                 {
       //                     using (Stream datastream = response.GetResponseStream())
       //                     {
       //                     StreamReader readerStream = null;

       //                     if (response.CharacterSet == null)
       //                         readerStream = new StreamReader(datastream);
       //                     else
       //                         readerStream= new StreamReader(datastream, Encoding.GetEncoding(response.CharacterSet()));

       //                        htmlCorreo = readerStream.ReadToEnd();
       //                         response.Close();
       //                         readerStream.Close();


       //                     }
       //                 }
       //                 if(htmlCorreo != "")
       //                 {
       //                     await _Correorepositorio.EnviarCorreo(usuario_creado.Correo, "Cuenta creada", htmlCorreo);

       //                 }
                       
       //             }
                
       //         IQueryable<Usuario> query = await _repositorio.Consultar(u => u.IdUsuario == usuario_creado.IdUsuario);
       //         usuario_creado = query.Include(r => r.IdRolNavigation).First();

       //         return usuario_creado;
       //     }
       //     catch(Exception ex)
       //     {
       //         throw;
       //     }
       // }

       // public async Task<Usuario> Editar(Usuario entidad, Stream Foto = null, string NombreFoto = "")
       // {
       //     Usuario usuario_existe = await _repositorio.Obtener(u => u.Correo == entidad.Correo && u.IdUsuario!=entidad.IdUsuario);

       //     if (usuario_existe != null)
       //     {
       //         throw new TaskCanceledException("Ya existe");

       //     }
       //     try
       //     {
       //         IQueryable<Usuario> queryUsuario = await _repositorio.Consultar(u =>);
       //     }
       // }

      
  }
}
