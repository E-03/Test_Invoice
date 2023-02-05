using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{

    [Table("Invoice")]
    public partial class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalItbis { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
