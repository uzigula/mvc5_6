using System;

namespace TiendaMusica.Logica.Comun
{
    internal class Utilidades
    {
        internal static string TransformarNombre(string nombre)
        {
            string nuevoNombre = nombre.Replace("_", " ");
            return nuevoNombre.Replace("-", "/");
        }
    }
}