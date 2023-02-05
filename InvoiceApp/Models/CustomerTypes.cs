namespace InvoiceApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerTypes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string Description { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
