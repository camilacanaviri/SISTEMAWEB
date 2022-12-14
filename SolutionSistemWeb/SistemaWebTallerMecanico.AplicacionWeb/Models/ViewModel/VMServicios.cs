using SistemWebTaller.Entity;

namespace SistemaWebTallerMecanico.AplicacionWeb.Models.ViewModel
{
    public class VMServicios
    {
        public int IdServicio { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        public int? Unidad { get; set; }

        public decimal? Precio { get; set; }

        public bool? Estado { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
    }
}
