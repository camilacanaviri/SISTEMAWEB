using SistemWebTaller.Entity;

namespace SistemaWebTallerMecanico.AplicacionWeb.Models.ViewModel
{
    public class VMCompra
    {
        public int IdCompra { get; set; }

        public string? NumeroCompra { get; set; }

        public int? IdTipoDocumentoCompra { get; set; }

        public int? IdUsuario { get; set; }

        public string? DocumentoCliente { get; set; }

        public string? NombreCliente { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? Total { get; set; }

        public DateTime? FechaRegistro { get; set; }

       
    }
}
