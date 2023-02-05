using AutoMapper;
using InvoiceApp.Dto;
using InvoiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.ConfigurationMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<CustomerTypes, CustomerTypesDto>().ReverseMap();

            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceDetail, InvoiceDetailDto>().ReverseMap();

        }
    }
}