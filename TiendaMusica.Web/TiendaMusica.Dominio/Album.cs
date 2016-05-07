namespace TiendaMusica.Dominio
{
    using System.Collections.Generic;

    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Track> Track { get; set; }
    }
}
