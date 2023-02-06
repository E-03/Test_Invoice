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

namespace InvoiceApp.Data
{
    public class CustomerData : ICustomerServiceRepository
    {
        private readonly IRepositoryWrapper _repo;
        public CustomerData(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddCustomer(CustomersDto customers)
        {
            bool isSaved = false;
            try
            {
                var customerMapper = Mapper.Map<CustomersDto, Customers>(customers);
                var saved = await _repo.Customers.Insert(customerMapper);

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

        public void DeleteCustomer(CustomersDto customers)
        {
            var customerMapper = Mapper.Map<CustomersDto, Customers>(customers);

            _repo.Customers.Delete(customerMapper);
        }

        public async Task<IEnumerable<CustomersDto>> GetCustomers()
        {
            try
            {
                IEnumerable<Customers> customers = await _repo.Customers.GetAll();

                var customerMapper = Mapper.Map<IEnumerable<Customers>, IEnumerable<CustomersDto>>(customers);

                if (!customers.Any())
                    throw new Exception($"No existen datos para {nameof(CustomersDto)}");

                return customerMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomersDto> GetOneCustomers(int id)
        {
            try
            {
                Customers customer = await _repo.Customers.GetById(id);

                CustomersDto customerMapper = Mapper.Map<Customers, CustomersDto>(customer);

                if (customer.Id.Equals(0))
                    throw new Exception($"No existen datos para el id {id}.");

                return customerMapper;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCustomer(CustomersDto customers)
        {
            try
            {
                bool updated = false;
                customers.Status = true;
                var customerMapper = Mapper.Map<CustomersDto, Customers>(customers);

                var isUpdated = await _repo.Customers.Modify(customerMapper);

                if (!isUpdated)
                    throw new Exception($"Error al modificar el registro con el id: {customerMapper.Id}.");

                updated = true;
                
                return updated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}