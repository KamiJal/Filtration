using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filtration.Utility;

namespace Filtration.Filters
{
    public class ErrorListAuthorizeAttribute : AuthorizeAttribute
    {

        public ErrorListAuthorizeAttribute() {}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var adminOrManager = Users.Equals(httpContext.User.Identity.Name) || httpContext.User.IsInRole(RoleNames.Admin);
            return httpContext.Request.IsAuthenticated && adminOrManager;
        }
    }
}