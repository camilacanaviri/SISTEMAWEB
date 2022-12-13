using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class CargoMenu
{
    public int IdCargoMenu { get; set; }

    public int? IdCargo { get; set; }

    public int? IdMenu { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }
}
