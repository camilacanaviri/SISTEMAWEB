using Microsoft.AspNetCore.Mvc;

namespace SistemaWebTallerMecanico.AplicacionWeb.Controllers
{
    public class CompraController : Controller
    {
        public IActionResult NuevaCompra()
        {
            return View();
        }
        public IActionResult HistorialCompra()
        {
            return View();
        }
    }
}
