using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;

namespace MVCApp.Filters
{
    public class AdminOnlyFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var usertype = context.HttpContext.Session.GetString("usertype");
            if (usertype != "admin")
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }

        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}