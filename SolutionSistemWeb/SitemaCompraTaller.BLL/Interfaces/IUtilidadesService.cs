using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SitemaCompraTaller.BLL.Interfaces
{
    public interface IUtilidadesService
    {

        string GenerarClave();
        string ConvertiSha256(string texto);
    }
}
