using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdCompra { get; set; }

    public int? IdServicio { get; set; }

    public string? DescripcionServicio { get; set; }

    public string? CategoriaServicio { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual CompraServicio? IdCompraNavigation { get; set; }
}
