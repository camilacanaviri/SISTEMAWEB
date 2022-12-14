using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdRol { get; set; }

    public string? UrlFoto { get; set; }

    public string? NombreFoto { get; set; }

    public string? Clave { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CompraServicio> CompraServicios { get; } = new List<CompraServicio>();

    public virtual Cargo? IdRolNavigation { get; set; }
}
