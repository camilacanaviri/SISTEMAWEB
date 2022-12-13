using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class CompraServicio
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

    public virtual TipoDocumentoCompra? IdTipoDocumentoCompraNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
