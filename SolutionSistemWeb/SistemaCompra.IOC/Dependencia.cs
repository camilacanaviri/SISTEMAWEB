using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaCompra.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaCompra.DAL.Interfaces;
using SistemaCompra.DAL.Implementacion;
using System.Runtime.CompilerServices;
using SitemaCompraTaller.BLL.Implementacion;
using SitemaCompraTaller.BLL.Interfaces;


namespace SistemaCompra.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbtallerMecanicoContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSQL"));
            });


            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<ICompraRepository, CompraRepository>();
           
            
            services.AddScoped<ICorreoService, CorreoService>();
            services.AddScoped<IfirebaseServices, FireBaseServicio>();


            services.AddScoped<IUtilidadesService, UtilidadesService>();
            services.AddScoped<IRolService, CategoriaService>();



        }



    }
    
}
