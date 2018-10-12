using System.Web;
using System.Web.Mvc;
using Filtration.Filters;

namespace Filtration
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            filters.Add(new GlobalExceptionHandler());
        }
    }
}
