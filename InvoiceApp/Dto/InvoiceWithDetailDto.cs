using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceApp.Dto
{
    public class InvoiceWithDetailDto : InvoiceDto
    {
        [Display(Name = "Nombre Cliente")]
        public string CustomerName { get; set; }
        public ICollection<InvoiceDetailDto> InvoiceDetailDto { get; set; }
    }
}