using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CargoMenu> CargoMenus { get; } = new List<CargoMenu>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
