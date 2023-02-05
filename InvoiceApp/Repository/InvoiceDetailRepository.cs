using InvoiceApp.Models;
using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository
{
    public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(InvoiceDataContext context) : base(context)
        {

        }
    }
}