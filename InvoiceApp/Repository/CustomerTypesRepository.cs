using InvoiceApp.Models;
using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.Repository
{
    public class CustomersTypesRepository: GenericRepository<CustomerTypes>, ICustomerTypeRepository
    {
        public CustomersTypesRepository(InvoiceDataContext context) : base(context)
        {

        }
    }
}