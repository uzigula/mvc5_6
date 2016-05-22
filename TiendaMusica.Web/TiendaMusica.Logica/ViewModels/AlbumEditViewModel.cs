namespace TiendaMusica.Logica.ViewModels
{
    public class AlbumEditViewModel
    {
        public int AlbumId { get; set; }
        public string Caratula { get; set; }
        public string CaratulaExtension { get; internal set; }
        public string Titulo { get; set; }
    }
}