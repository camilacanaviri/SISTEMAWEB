using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemWebTaller.Entity;

namespace SistemaCompra.DAL.Interfaces
{
    public interface ICompraRepository :IGenericRepository<CompraServicio>

    {
        Task<CompraServicio> Registrar(CompraServicio entidad);
        Task<List<DetalleCompra>> Responde(DateTime Fechainicio, DateTime Fechafin);
        Task<List<DetalleCompra>> Réporte(DateTime Fechainicio, DateTime Fechafin);
    }
}
