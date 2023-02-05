using InvoiceApp.Dto;
using InvoiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvoiceApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceServiceRepository _invoiceServiceRepository;
        private readonly IInvoiceDetailServiceRepository _invoiceDetailServiceRepository;
        public InvoiceController(IInvoiceServiceRepository invoiceServiceRepository,
            IInvoiceDetailServiceRepository invoiceDetailServiceRepository)
        {
            _invoiceServiceRepository = invoiceServiceRepository;
            _invoiceDetailServiceRepository = invoiceDetailServiceRepository;
        }

        [HttpPost]
        public async Task<ActionResult> SaveInvoiceWithDetail(InvoiceWithDetailDto InvoiceWithDetailDto)
        {
            try
            {
                var response = await _invoiceServiceRepository.InvoiceSave(InvoiceWithDetailDto);
                if(response)
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;

                    return new JsonResult
                    {
                        Data = new { message = "El registro se actualizó correctamente!" },
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                
                return new JsonResult
                {
                    Data = new { message = "Error actualizando el cliente, Favor verificar." },
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}