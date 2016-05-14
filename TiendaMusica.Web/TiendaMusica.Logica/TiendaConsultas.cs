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
            // usando un ORM
            //return db.Albums.GetAll()
            //        .Where(a => a.Artist.Name == nombreConvertido)
            //        .Select(o => new AlbumsPorArtistaViewModel
            //            {
            //                Album = o.Title,
            //                Artista = o.Artist.Name 
            //            }).ToList();


            // Usando InsightDatabase

            return db
                .ConsultaAdHoc<AlbumsPorArtistaViewModel>
                        (
                        "Select a.Title Album, b.Name Artista from dbo.Album a inner join dbo.Artist b on a.ArtistId=b.ArtistId where b.Name = @Name", 
                        new { Name = nombre }
                        );


        }
    }
}