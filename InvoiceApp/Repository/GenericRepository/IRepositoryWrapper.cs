using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Repository.GenericRepository
{
    public interface IRepositoryWrapper
    {
        ICustomersRepository Customers { get; }
        ICustomerTypeRepository CustomerTypes { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceDetailRepository InvoiceDetail { get; }
    }
}
