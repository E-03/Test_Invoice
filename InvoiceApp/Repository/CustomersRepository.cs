using InvoiceApp.Models;
using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository
{
    public class CustomersRepository : GenericRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(InvoiceDataContext context): base(context)
        {

        }
    }
}