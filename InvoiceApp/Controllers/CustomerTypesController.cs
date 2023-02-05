using AutoMapper;
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
    public class CustomerTypesController : Controller
    {
        private readonly ICustomerTypesServiceRepository _repoCustomerTypes;
        public CustomerTypesController(ICustomerTypesServiceRepository repoCustomerTypes)
        {
            _repoCustomerTypes = repoCustomerTypes;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetCustomersTypes()
        {
            try
            {
                var customersTypes = await _repoCustomerTypes.GetCustomersTypes();

                return new JsonResult
                {
                    Data = customersTypes,
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
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
                var customertypes = await _repoCustomerTypes.GetOneCustomersTypes(id);

                return new JsonResult()
                {
                    Data = customertypes,
                    ContentType = "application/json",
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
        public async Task<ActionResult> PostCustomerTypes(CustomerTypesDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Favor verificar campos obligatorios");
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;

                    return new JsonResult
                    {
                        Data = new { message = "Existen campos vacios, Favor rellenarlos" },
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };

                }

                var saved = await _repoCustomerTypes.AddCustomerTypes(dto);

                if (!saved)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult
                    {
                        Data = new { message = "Error insertando el cliente, Favor verificar." },
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }

                Response.StatusCode = (int)HttpStatusCode.Created;

                return new JsonResult
                {
                    Data = new { message = "El registro se inserto correctamente!" },
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult
                {
                    Data = new { message = ex.Message },
                    ContentType = "application/json",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

            }
        }

        [HttpPatch]
        public async Task<ActionResult> PutCustomer(CustomerTypesDto dto)
        {
            try
            {
                var updated = await _repoCustomerTypes.UpdateCustomerTypes(dto);

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
