using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<ServiciosGenerale> ServiciosGenerales { get; } = new List<ServiciosGenerale>();
}
