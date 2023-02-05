using InvoiceApp.Dto;
using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApp.Services
{
    public interface ICustomerServiceRepository
    {
        Task<IEnumerable<CustomersDto>> GetCustomers();
        Task<CustomersDto> GetOneCustomers(int id);
        Task<bool> AddCustomer(CustomersDto customers);
        Task<bool> UpdateCustomer(CustomersDto customers);
        void DeleteCustomer(CustomersDto customers);
    }
}
