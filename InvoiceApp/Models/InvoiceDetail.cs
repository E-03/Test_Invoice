using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("InvoiceDetail")]
    public partial class InvoiceDetail
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int Qty { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalItbis { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
