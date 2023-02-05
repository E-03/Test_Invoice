using InvoiceApp.Models;
using InvoiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using InvoiceApp.ValidationErrors;
using InvoiceApp.Dto;
using AutoMapper;

namespace InvoiceApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServiceRepository _repoCustomer;
        private readonly ICustomerTypesServiceRepository _repoCustomerTypes;
        public CustomersController(ICustomerServiceRepository repoCustomer,
                                   ICustomerTypesServiceRepository repoCustomerTypes)
        {
            _repoCustomer = repoCustomer;
            _repoCustomerTypes = repoCustomerTypes;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.fillCustomerTypes = await _repoCustomerTypes.GetCustomerTypeDD();
            return View();
        }

        public async Task<ActionResult> ListadoPage(CustomersDto dto)
        
        {
            ViewBag.EditCustomerTypeDD = new SelectList(await _repoCustomerTypes.GetCustomersTypes(), "Id", "Description", dto.CustomerTypeId);
            return View(new CustomersDto());
        }

        [HttpGet]
        public async Task<JsonResult> GetCustomers()
        {
            try
            {
                var customers = await _repoCustomer.GetCustomers();
                
                return new JsonResult { 
                    Data = customers, 
                    ContentType = "application/json", 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet  };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetOneCustomers(int id)
        {
            try
            {
                var customer = await _repoCustomer.GetOneCustomers(id);

                ViewBag.EditCustomerTypeDD = new SelectList(await _repoCustomerTypes.GetCustomersTypes(), "Id", "Description", customer.CustomerTypeId);
                
                return new JsonResult() { 
                    Data = customer, ContentType = "application/json", 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PostCustomers(CustomersDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Favor verificar campos obligatorios");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    return new JsonResult { 
                        Data = new { message = "Existen campos vacios, Favor rellenarlos" }, 
                        ContentType = "application/json", 
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                    };

                }
                
                dto.Status = true;

                var saved = await _repoCustomer.AddCustomer(dto);
                
                if (!saved)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult { 
                        Data = new { message = "Error insertando el cliente, Favor verificar." }, 
                        ContentType = "application/json", 
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }

                Response.StatusCode = (int)HttpStatusCode.Created;
                
                return new JsonResult { 
                    Data = new { message = "El registro se inserto correctamente!" }, 
                    ContentType = "application/json", 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult { 
                    Data = new { message = ex.Message }, 
                    ContentType = "application/json", 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                
            }
        }

        [HttpPatch]
        public async Task<ActionResult> PutCustomer(CustomersDto dto)
        {
            try
            {
                var updated = await _repoCustomer.UpdateCustomer(dto);

                if (!updated)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { message = "Error actualizando el cliente, Favor verificar." },
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                Response.StatusCode = (int)HttpStatusCode.OK;

                return new JsonResult
                {
                    Data = new { message = "El registro se actualizó correctamente!" },
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                return new JsonResult
                {
                    Data = new { message = $"{ex.Message}" },
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            
        }
    }
}