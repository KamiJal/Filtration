using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtration.Models;
using Filtration.Utility;

namespace Filtration.Controllers
{
    [Authorize(Roles = RoleNames.SalesManager)]
    public class SalesManagerController : Controller
    {
        // GET: SalesManager
        public ActionResult VisitorsList()
        {
            using (var context = new ApplicationDbContext())
            {
                var visitorsList = context.LoggingContactsVisitors.ToList();
                return View(visitorsList);
            }            
        }
    }
}