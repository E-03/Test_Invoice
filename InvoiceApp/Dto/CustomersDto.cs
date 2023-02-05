using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Dto
{
    public class CustomersDto
    {
        [Display(Name = "Cliente Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(70)]
        [Display(Name = "Cliente")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(120)]
        [Display(Name = "Dirección")]
        public string Adress { get; set; }

        [Display(Name = "Estatus")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Tipo Cliente")]
        public int CustomerTypeId { get; set; }
    }
}