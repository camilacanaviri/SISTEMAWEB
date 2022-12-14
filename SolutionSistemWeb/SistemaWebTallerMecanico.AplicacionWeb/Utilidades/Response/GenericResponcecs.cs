﻿namespace SistemaWebTallerMecanico.AplicacionWeb.Utilidades.Response
{
    public class GenericResponcecs<TObject>

    {
        public bool Estado { get; set; }
        public string? Mensaje { get; set; }
        public TObject? Objeto { get; set; }
        public List<TObject> ? ListaObjeto { get; set; }
    }
}
