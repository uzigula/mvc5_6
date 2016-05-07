namespace TiendaMusica.Dominio
{
    using System;
    using System.Collections.Generic;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceLine = new HashSet<InvoiceLine>();
        }

        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string BillingAddress { get; set; }

        public string BillingCity { get; set; }

        public string BillingState { get; set; }

        public string BillingCountry { get; set; }

        public string BillingPostalCode { get; set; }

        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLine { get; set; }
    }
}
