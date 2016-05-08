using System.Collections.Generic;
using System.Linq;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Logica.Comun;
using TiendaMusica.Logica.ViewModels;

namespace TiendaMusica.Logica
{
    public class TiendaConsultas
    {
        private readonly ITiendaMusicaRepository db;
        public TiendaConsultas(ITiendaMusicaRepository repositorio)
        {
            db = repositorio;
        }
        public IEnumerable<AlbumsPorArtistaViewModel> Albums(string nombre)
        {
            string nombreConvertido = Utilidades.TransformarNombre(nombre);

            return db.Albums.GetAll()
                    .Where(a => a.Artist.Name == nombreConvertido)
                    .Select(o => new AlbumsPorArtistaViewModel
                        {
                            Album = o.Title,
                            Artista = o.Artist.Name 
                        }).ToList();

        }
    }
}