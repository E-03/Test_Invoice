using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceApp.Dto
{
    public class CustomerTypesDto
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        [StringLength(70)]
        public string Description { get; set; }
    }
}