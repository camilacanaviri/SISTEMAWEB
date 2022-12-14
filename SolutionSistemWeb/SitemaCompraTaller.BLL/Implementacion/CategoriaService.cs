using SistemWebTaller.Entity;
using SitemaCompraTaller.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCompra.DAL.Interfaces;

namespace SitemaCompraTaller.BLL.Implementacion
{
    public class CategoriaService : IRolService
    {
        private readonly IGenericRepository<Configuracion> _repositorio;
        public CategoriaService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;

        }
        public async Task<List<Cargo>> Lista()
        {
            IQueryable<Cargo> query = (IQueryable<Cargo>)await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
