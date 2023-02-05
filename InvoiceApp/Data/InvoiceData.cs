using InvoiceApp.Dto;
using InvoiceApp.Models;
using InvoiceApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InvoiceApp.Data
{
    public class InvoiceData : IInvoiceServiceRepository
    {
        private readonly IInvoiceDetailServiceRepository _invoiceDetailRepo;
        private readonly ICustomerServiceRepository _customerRepo;
        private readonly InvoiceDataContext _context;
        public InvoiceData(IInvoiceDetailServiceRepository invoiceDetailRepo, ICustomerServiceRepository customerRepo, InvoiceDataContext context)
        {
            _invoiceDetailRepo = invoiceDetailRepo;
            _customerRepo = customerRepo;
            _context = context;
        }
        public async Task<bool> InvoiceSave(InvoiceWithDetailDto invoice)
        {
            bool saved = false;
            var Customer = await _customerRepo.GetOneCustomers(invoice.CustomerId);

            var InvoiceHeader = new Invoice()
            {
                Id = invoice.Id,
                CustomerId = Customer.Id,
                SubTotal = 0,
                TotalItbis = 0,
                Total = 0
            };

            _context.Invoice.Add(InvoiceHeader);
            int i = await _context.SaveChangesAsync();

            invoice.Id = InvoiceHeader.Id;

            using (DbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    
                    if (i > 0)
                    {
                        bool isDetailSaved = await _invoiceDetailRepo.InvoiceDetailSave(invoice.CustomerId, invoice);

                        if (isDetailSaved)
                        {
                            transaction.Commit();
                            saved = true;
                        }
                        else
                            saved = false;
                        
                        return saved;
                    }

                    return saved;
                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    throw new DbEntityValidationException(ex.Message);
                }
            }  
        }
    }
}