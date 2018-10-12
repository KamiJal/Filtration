using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Filtration.Models;
using Filtration.ViewModels;

namespace Filtration.Filters
{
    public class GlobalExceptionHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;

            var loggingManager = new LoggingManager();
            loggingManager.LogException(filterContext.Exception);

            var viewModel = new ExceptionHandlerViewModel(filterContext.Exception);

            filterContext.Result = new ViewResult
            {
                ViewName = "ExceptionHandler",
                ViewData = new ViewDataDictionary(viewModel)
            };

            filterContext.ExceptionHandled = true;
        }
    }
}