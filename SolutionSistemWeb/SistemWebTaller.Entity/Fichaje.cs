using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Fichaje
{
    public int IdFichaje { get; set; }

    public string? IdPlaca { get; set; }

    public int? CambioKms { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Vehiculo? IdPlacaNavigation { get; set; }
}
