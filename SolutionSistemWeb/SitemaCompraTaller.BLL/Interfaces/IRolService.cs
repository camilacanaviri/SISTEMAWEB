using SistemWebTaller.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitemaCompraTaller.BLL.Interfaces
{
    public interface IRolService
    {
        Task<List<Cargo>>Lista();
    }
}
