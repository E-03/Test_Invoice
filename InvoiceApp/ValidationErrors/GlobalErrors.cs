using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceApp.ValidationErrors
{
    public static class GlobalErrors
    {
        public static string ErrorModel(IEnumerable<dynamic> errors)
        {
            string ErrorMessage = String.Empty;
            
            foreach (var item in errors)
            {
                ErrorMessage += " - " +  item.Errors[0].ErrorMessage;
            }

            return ErrorMessage;
        }
    }
}