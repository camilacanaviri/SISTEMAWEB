using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitemaCompraTaller.BLL.Interfaces
{
    public interface IfirebaseServices
    {
        Task<string> SubirStorage(Stream StreamsActivo, string CarpetaDestino, string NombreActivo);
        Task<bool> EliminarStorage(string CarpetaDestino, string NombreActivo);

    }
}
