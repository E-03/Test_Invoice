namespace InvoiceApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        //public Customers()
        //{
        //    Invoice = new HashSet<Invoice>();
        //}

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string CustName { get; set; }

        [Required]
        [StringLength(120)]
        public string Adress { get; set; }

        public bool Status { get; set; }

        public int CustomerTypeId { get; set; }

        public virtual CustomerTypes CustomerTypes { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
