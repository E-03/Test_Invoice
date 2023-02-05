using InvoiceApp.Dto;
using InvoiceApp.Models;
using InvoiceApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InvoiceApp.Data
{
    public class InvoiceDetailData : IInvoiceDetailServiceRepository
    {
        private readonly InvoiceDataContext _context;
    
        public InvoiceDetailData(InvoiceDataContext context)
        {
            _context = context;
        }

        public async Task<bool> InvoiceDetailSave(int CustomerId, InvoiceWithDetailDto dto)
        {
            try
            {
                bool isSaved = false;
                var isInvoiceCalculated = 0;
                
                var calculateInvoice = InvoiceCalculateTotal(dto);

                var GetInvoiceToCalculateTotal = await _context.Invoice.FindAsync(dto.Id);

                //Calculate Invoice Amount and Modify
                GetInvoiceToCalculateTotal.SubTotal = calculateInvoice.SubTotal;
                GetInvoiceToCalculateTotal.TotalItbis = calculateInvoice.TotalItbis;
                GetInvoiceToCalculateTotal.Total = calculateInvoice.Total;
                _context.Entry(GetInvoiceToCalculateTotal).State = EntityState.Modified;

                //Calculate Invoice Detail Amount and Modifiy
                var InvoiceDetailCalculate = InvoiceDetailCalculateTotal(dto.InvoiceDetailDto);

                dto.InvoiceDetailDto = InvoiceDetailCalculate;

                foreach (var item in dto.InvoiceDetailDto)
                {
                    item.CustomerId = CustomerId;
                    var invoiceDetail = new InvoiceDetail()
                    {
                        CustomerId = CustomerId,
                        Qty = item.Qty,
                        Price = item.Price,
                        SubTotal = item.SubTotal,
                        TotalItbis = item.TotalItbis,
                        Total = item.Total
                    };

                    _context.InvoiceDetail.Add(invoiceDetail);
                }

                int isDetailSave = await _context.SaveChangesAsync();
                if (isDetailSave > 0) isSaved = true;

                return isSaved;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<InvoiceDetailDto> InvoiceDetailCalculateTotal(ICollection<InvoiceDetailDto> dto)
        {
            try
            {
                var InvoiceDetailList = new List<InvoiceDetailDto>();

                foreach (var item in dto)
                {
                    var InvoiceDetail = new InvoiceDetailDto()
                    {
                        CustomerId = item.CustomerId,
                        Qty = item.Qty,
                        Price = item.Price,
                        SubTotal = (item.Price * item.Qty),
                        TotalItbis = ((item.Price * item.Qty) * 0.18M) / 100,
                        Total = (item.Price * item.Qty) + ((item.Price * item.Qty) * 0.18M) / 100
                    };

                    InvoiceDetailList.Add(InvoiceDetail);
                }
               
                return InvoiceDetailList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public InvoiceDto InvoiceCalculateTotal(InvoiceWithDetailDto dto)
        {
            try
            {

                var SubTotal = dto.InvoiceDetailDto.Sum(p => (p.Price * p.Qty));
                var TotalItbis = (SubTotal * 0.18M) / 100;
                var Total = (SubTotal + TotalItbis);
               

                return new InvoiceDto() { 
                    SubTotal = SubTotal,
                    TotalItbis = TotalItbis,
                    Total = Total
                };
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}