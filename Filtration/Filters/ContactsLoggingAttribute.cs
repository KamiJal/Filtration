using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtration.Models;

namespace Filtration.Filters
{
    public class ContactsLoggingAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var loggingManager = new LoggingManager();
            loggingManager.LogContactsVisitor();
        }
    }
}