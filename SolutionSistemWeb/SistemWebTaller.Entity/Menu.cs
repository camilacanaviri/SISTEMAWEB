using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Menu
{
    public int IdMenu { get; set; }

    public string? Descripcion { get; set; }

    public int? IdMenuMayor { get; set; }

    public string? Icono { get; set; }

    public string? Controlador { get; set; }

    public string? PaginaAccion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<CargoMenu> CargoMenus { get; } = new List<CargoMenu>();

    public virtual Menu? IdMenuMayorNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdMenuMayorNavigation { get; } = new List<Menu>();
}
