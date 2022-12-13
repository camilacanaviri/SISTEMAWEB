using System;
using System.Collections.Generic;

namespace SistemWebTaller.Entity;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? UrlLogo { get; set; }

    public string? NombreLogo { get; set; }

    public string? NumeroDocumento { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? SimboloMoneda { get; set; }
}
