using Microsoft.AspNetCore.Mvc;

namespace SistemaWebTallerMecanico.AplicacionWeb.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
