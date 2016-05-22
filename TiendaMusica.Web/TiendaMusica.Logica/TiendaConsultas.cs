using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Logica.Comun;
using TiendaMusica.Logica.ViewModels;
using System.Drawing;


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
            return db.Albums.GetAll()
                    .Where(a => a.Artist.Name == nombreConvertido)
                    .Select(o => new AlbumsPorArtistaViewModel
                    {
                        Album = o.Title,
                        Artista = o.Artist.Name
                    }).ToList();


            // Usando InsightDatabase

            //return db
            //    .ConsultaAdHoc<AlbumsPorArtistaViewModel>
            //            (
            //            "Select a.Title Album, b.Name Artista from dbo.Album a inner join dbo.Artist b on a.ArtistId=b.ArtistId where b.Name = @Name", 
            //            new { Name = nombreConvertido }
            //            );


        }

        public void GrabarAlbum(AlbumEditViewModel model, Imagen imagen)
        {
            if (imagen == null) { GrabarAlbum(model); return; }

            var thumbnailPath = model.AlbumId.ToString().PadLeft(10, '0').GetMD5();

            model.Caratula = thumbnailPath;
            model.CaratulaExtension = Path.GetExtension(imagen.Nombre).Replace(".","");

            imagen.GrabaThumbnail( model.Caratula + Path.GetExtension(imagen.Nombre));
            GrabarAlbum(model);

                
        }

        private void GrabarAlbum(AlbumEditViewModel model)
        {
            var album = db.Albums.Single(x => x.AlbumId == model.AlbumId);
            album.Title = model.Titulo;
            album.Thumbnail = model.Caratula;
            album.ThumbnailExtension = model.CaratulaExtension;
            db.Albums.Update(album);
            db.Commit();

        }

        public AlbumEditViewModel AlbumParaEditar(string artista, string album)
        {
            string nombreConvertido = Utilidades.TransformarNombre(artista);
            var result = db.Albums.Single(x => x.Artist.Name == nombreConvertido && x.Title == album);
            if (result == null) throw new NotDataFoundException("No se encontro el Album");
            return new AlbumEditViewModel
            {
                AlbumId = result.AlbumId,
                Titulo = result.Title,
                Caratula = result.Thumbnail,
                CaratulaExtension = result.ThumbnailExtension

            };
        }
    }
}