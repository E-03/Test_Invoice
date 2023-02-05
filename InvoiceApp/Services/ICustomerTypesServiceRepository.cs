using InvoiceApp.Dto;
using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InvoiceApp.Services
{
    public interface ICustomerTypesServiceRepository
    {
        Task<IEnumerable<CustomerTypesDto>> GetCustomersTypes();
        Task<CustomerTypesDto> GetOneCustomersTypes(int id);
        Task<bool> AddCustomerTypes(CustomerTypesDto model);
        Task<bool> UpdateCustomerTypes(CustomerTypesDto model);
        void DeleteCustomerTypes(CustomerTypesDto model);
        Task<IEnumerable<SelectListItem>> GetCustomerTypeDD();
    }
}
