using InvoiceApp.Dto;
using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InvoiceApp.Services
{
    public interface IInvoiceDetailServiceRepository
    {
        Task<bool> InvoiceDetailSave(int CustomerId, InvoiceWithDetailDto dto);
        InvoiceDto InvoiceCalculateTotal(InvoiceWithDetailDto dto);
    }
}