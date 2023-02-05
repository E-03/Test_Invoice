using InvoiceApp.Controllers;
using InvoiceApp.Data;
using InvoiceApp.Repository.GenericRepository;
using InvoiceApp.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace InvoiceApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepositoryWrapper, RepositoryWrapper>();
            container.RegisterType<ICustomerServiceRepository, CustomerData>();
            container.RegisterType<ICustomerTypesServiceRepository, CustomerTypesData>();
            container.RegisterType<IInvoiceServiceRepository, InvoiceData>();
            container.RegisterType<IInvoiceDetailServiceRepository, InvoiceDetailData>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}