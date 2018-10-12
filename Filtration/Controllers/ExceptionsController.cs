using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtration.Controllers
{
    public class ExceptionsController : Controller
    {
        public ActionResult ExceptionsList()
        {
            return View();
        }

        public ActionResult GetNullReferenceException()
        {
            throw new NullReferenceException();
        }

        public ActionResult GetArgumentNullException()
        {
            throw new ArgumentNullException();
        }

        public ActionResult GetArgumentOutOfRangeException()
        {
            throw new ArgumentOutOfRangeException();
        }

        public ActionResult GetFileNotFoundException()
        {
            throw new FileNotFoundException();
        }

        public ActionResult GetDivideByZeroException()
        {
            throw new DivideByZeroException();
        }

        public ActionResult GetIndexOutOfRangeException()
        {
            throw new IndexOutOfRangeException();
        }

        public ActionResult GetInvalidOperationException()
        {
            throw new InvalidOperationException();
        }
    }
}