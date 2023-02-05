using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceApp.Dto
{
    public class InvoiceDetailDto
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

    }
}