using Microsoft.AspNetCore.Mvc;

namespace SistemaWebTallerMecanico.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
