using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtration.Models;
using Filtration.Utility;

namespace Filtration.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    [Authorize(Users = UserNames.Manager)]
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult ErrorList()
        {
            using (var context = new ApplicationDbContext())
            {
                var errorList = context.LoggingExceptions.ToList();
                return View(errorList);
           }           
        }
    }
}