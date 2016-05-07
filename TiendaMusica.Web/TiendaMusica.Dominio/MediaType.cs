namespace TiendaMusica.Dominio
{
    using System.Collections.Generic;

    public partial class MediaType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }

        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Track> Track { get; set; }
    }
}
