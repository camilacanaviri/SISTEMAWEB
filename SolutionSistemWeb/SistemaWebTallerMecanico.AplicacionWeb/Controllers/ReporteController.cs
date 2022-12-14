using Microsoft.AspNetCore.Mvc;

namespace SistemaWebTallerMecanico.AplicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
