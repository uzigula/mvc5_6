using System;
using System.Drawing;
using System.IO;

namespace TiendaMusica.Logica.Comun
{
    public class Imagen
    {

        public Imagen(MemoryStream stream, string fileName, string contentType, string ruta)
        {
            Stream = stream;
            this.Nombre = fileName;
            this.Tipo = contentType;
            Ruta = ruta;
        }

        public string Nombre { get; private set; }
        public string Ruta { get; private set; }
        public MemoryStream Stream { get; private set; }
        public string Tipo { get; private set; }

        public void GrabaThumbnail(string nombreArchivo)
        {
            string archivoTemporal = NombreArchivo(Path.GetExtension(Nombre));
            GuardaArchivoOriginal(archivoTemporal);
            using (var image = Image.FromFile(archivoTemporal))
            {
                var scale = Math.Min((float)200 / image.Width, (float)200 / image.Height);
                var scaleWidth = (int)(image.Width * scale);
                var scaleHeight = (int)(image.Height * scale);
                using (var thumbnail = image.GetThumbnailImage(scaleWidth, scaleHeight, null, IntPtr.Zero))
                {
                    thumbnail.Save(Path.Combine(Ruta, nombreArchivo));
                }
            }
        }

        private void GuardaArchivoOriginal(string archivoTemporal)
        {
            FileStream fs = new FileStream(archivoTemporal, FileMode.CreateNew);
            Stream.Position = 0;
            Stream.CopyTo(fs);
            fs.Position = 0;
            fs.Flush();
            fs.Close();
        }

        private string NombreArchivo(string ext)
        {
            var ruta = Path.GetTempFileName();
            File.Delete(ruta);
            return Path.ChangeExtension(ruta, ext);
        }
    }
    }