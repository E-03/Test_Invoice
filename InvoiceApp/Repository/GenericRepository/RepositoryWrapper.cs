using InvoiceApp.Models;
using InvoiceApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Repository.GenericRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InvoiceDataContext _context;
        private ICustomersRepository _Customers;
        private IInvoiceRepository _Invoice;
        private ICustomerTypeRepository _CustomerTypes;
        private IInvoiceDetailRepository _InvoiceDetail;

        public RepositoryWrapper(InvoiceDataContext context)
        {
            _context = context;
        }

        public ICustomersRepository Customers
        {
            get
            {
                if (_Customers == null) _Customers = new CustomersRepository(_context);
                return _Customers;
            }
        }

        public IInvoiceRepository Invoice
        {
            get
            {
                if (_Invoice == null) _Invoice = new InvoiceRepository(_context);
                return _Invoice;
            }
        }

        public IInvoiceDetailRepository InvoiceDetail
        {
            get
            {
                if (_InvoiceDetail == null) _InvoiceDetail = new InvoiceDetailRepository(_context);
                return _InvoiceDetail;
            }
        }


        public ICustomerTypeRepository CustomerTypes
        {
            get
            {
                if (_CustomerTypes == null) _CustomerTypes = new CustomersTypesRepository(_context);
                return _CustomerTypes;
            }
        }
    }
}
