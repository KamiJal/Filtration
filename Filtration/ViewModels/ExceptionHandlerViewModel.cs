using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filtration.ViewModels
{
    public class ExceptionHandlerViewModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ExceptionHandlerViewModel()
        {
            
        }

        public ExceptionHandlerViewModel(Exception exception)
        {
            Name = exception.GetType().Name;
            Message = exception.Message;
            StackTrace = exception.StackTrace;
        }
    }
}