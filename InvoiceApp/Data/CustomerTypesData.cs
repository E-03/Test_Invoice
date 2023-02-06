using AutoMapper;
using InvoiceApp.Dto;
using InvoiceApp.Models;
using InvoiceApp.Repository.GenericRepository;
using InvoiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Data
{
    public class CustomerTypesData : ICustomerTypesServiceRepository
    {
        private readonly IRepositoryWrapper _repo;
        public CustomerTypesData(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddCustomerTypes(CustomerTypesDto model)
        {
            try
            {
                bool isSaved = false;
                var customerTypes = Mapper.Map<CustomerTypesDto, CustomerTypes>(model);
                var saved = await _repo.CustomerTypes.Insert(customerTypes);

                if (saved.Equals(0))
                    throw new Exception($"No se pudo insertar la información del usuario. Favor verificar!");

                isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCustomerTypes(CustomerTypesDto model)
        {
            var customerTypes = Mapper.Map<CustomerTypesDto, CustomerTypes>(model);
            _repo.CustomerTypes.Delete(customerTypes);
        }

        public async Task<IEnumerable<CustomerTypesDto>> GetCustomersTypes()
        {
            try
            {
                var custTypes = await _repo.CustomerTypes.GetAll();
                
                if (!custTypes.Any())
                    throw new Exception($"No existen datos para {nameof(Customers)}");
                
                var customersTypesData = Mapper.Map<IEnumerable<CustomerTypes>, IEnumerable<CustomerTypesDto>>(custTypes);

                return customersTypesData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomerTypesDto> GetOneCustomersTypes(int id)
        {
            try
            {
                CustomerTypes customer = await _repo.CustomerTypes.GetById(id);

                var customerTypes = Mapper.Map<CustomerTypes, CustomerTypesDto>(customer);

                if (customerTypes.Id > 0)
                    throw new Exception($"No existen datos para el id {id}.");

                return customerTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCustomerTypes(CustomerTypesDto model)
        {
            bool updated = false;
            try { 
            
                var customerTypes = Mapper.Map<CustomerTypesDto, CustomerTypes>(model);

                _repo.CustomerTypes.Modify(customerTypes);
                
                updated = true;
                
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetCustomerTypeDD()
        {
            var data = await _repo.CustomerTypes.GetAll() as List<CustomerTypes>;

            var mapperDto = Mapper.Map<List<CustomerTypes>, List<CustomerTypesDto>>(data);

            List<SelectListItem> customerTypes = mapperDto
                .OrderBy(p => p.Description)
                .Select(n => new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Description
                    }).ToList();

            var CustomerTypesNull = new SelectListItem()
            {
                Value = null,
                Text = "--- Seleccionar Tipo Cliente ---"
            };
            customerTypes.Insert(0, CustomerTypesNull);
            return new SelectList(customerTypes, "Value", "Text");
            
        }

    }
}