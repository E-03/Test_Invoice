using InvoiceApp.Models;
using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InvoiceDataContext context) : base (context)
        {

        }
    }
}