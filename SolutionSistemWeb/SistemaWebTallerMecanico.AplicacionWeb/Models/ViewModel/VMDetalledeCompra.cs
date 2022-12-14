namespace SistemaWebTallerMecanico.AplicacionWeb.Models.ViewModel
{
    public class VMDetalledeCompra
    {
        public int IdDetalleCompra { get; set; }

        public int? IdCompra { get; set; }

        public int? IdServicio { get; set; }

        public string? DescripcionServicio { get; set; }

        public string? CategoriaServicio { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Total { get; set; }
    }
}
