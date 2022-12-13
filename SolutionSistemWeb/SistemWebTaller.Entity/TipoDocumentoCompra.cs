using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class TipoDocumentoCompra
{
    public int IdTipoDocumentoCompra { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CompraServicio> CompraServicios { get; } = new List<CompraServicio>();
}
