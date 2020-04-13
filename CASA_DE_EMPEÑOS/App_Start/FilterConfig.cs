using System.Web;
using System.Web.Mvc;

namespace CASA_DE_EMPEÑOS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
