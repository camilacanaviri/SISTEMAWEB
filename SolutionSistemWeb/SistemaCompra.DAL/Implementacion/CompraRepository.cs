using Microsoft.EntityFrameworkCore;
using SistemaCompra.DAL.Interfaces;
using SistemWebTaller.Entity;
using SistemaCompra.DAL.DBContext;


namespace SistemaCompra.DAL.Implementacion
{
   public class CompraRepository :GenericRepository<CompraServicio>,ICompraRepository
    {
        private readonly DbtallerMecanicoContext _dbcontext;

        public CompraRepository(DbtallerMecanicoContext dbcontext):base (dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<CompraServicio> Registrar(CompraServicio entidad)
        {

            CompraServicio compragenerada = new CompraServicio();
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleCompra dv in entidad.DetalleCompras){

                        ServiciosGenerale servicio_encontrado = _dbcontext.ServiciosGenerales.Where(P => P.IdServicio == dv.IdServicio).First();
                        servicio_encontrado.Unidad =servicio_encontrado.Unidad - dv.Cantidad;
                        _dbcontext.ServiciosGenerales.Update(servicio_encontrado);
                     
                    }
                    await _dbcontext.SaveChangesAsync();

                    NumeroCorrelativo numeroCorrelativo = _dbcontext.NumeroCorrelativos.Where(n => n.Gestion == "compraservicio").First();
                    numeroCorrelativo.UltimoNumero = numeroCorrelativo.UltimoNumero + 1;
                    numeroCorrelativo.FechaActualizacion = DateTime.Now;

                    _dbcontext.NumeroCorrelativos.Update(numeroCorrelativo);
                    await _dbcontext.SaveChangesAsync();
                    string ceros = string.Concat(Enumerable.Repeat("0", numeroCorrelativo.CantidadDigitos.Value));
                    string numerocompra = ceros + numeroCorrelativo.UltimoNumero.ToString();
                    numerocompra = numerocompra.Substring(numerocompra.Length - numeroCorrelativo.CantidadDigitos.Value, numeroCorrelativo.CantidadDigitos.Value);

                    entidad.NumeroCompra = numerocompra;

                    await _dbcontext.CompraServicios.AddAsync(entidad);
                    await _dbcontext.SaveChangesAsync();

                    compragenerada = entidad;
                    transaction.Commit();

                }



                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw ex;
                }
                
            }
            return compragenerada;

        }

        public Task<List<DetalleCompra>> Responde(DateTime Fechainicio, DateTime Fechafin)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DetalleCompra>> Réporte(DateTime Fechainicio, DateTime Fechafin)
        {
            List<DetalleCompra> listaresumen = await _dbcontext.DetalleCompras
            .Include(v => v.IdCompraNavigation)
                .ThenInclude(u => u.IdUsuarioNavigation)
            .Include(v => v.IdCompraNavigation)
                .ThenInclude(dv => dv.IdTipoDocumentoCompraNavigation)
                .Where(dv => dv.IdCompraNavigation.FechaRegistro.Value.Date >= Fechainicio.Date &&
                dv.IdCompraNavigation.FechaRegistro.Value.Date <= Fechafin.Date).ToListAsync();

            return listaresumen;
        }

       
    }
}
