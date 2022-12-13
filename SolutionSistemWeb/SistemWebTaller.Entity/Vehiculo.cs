using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Vehiculo
{
    public string IdPlaca { get; set; } = null!;

    public int? IdCompra { get; set; }

    public int? IdServicio { get; set; }

    public string? Modelo { get; set; }

    public string? Marca { get; set; }

    public virtual ICollection<Fichaje> Fichajes { get; } = new List<Fichaje>();

    public virtual CompraServicio? IdCompraNavigation { get; set; }
}
