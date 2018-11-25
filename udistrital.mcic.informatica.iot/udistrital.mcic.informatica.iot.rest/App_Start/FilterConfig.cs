using System.Web;
using System.Web.Mvc;

namespace udistrital.mcic.informatica.iot.rest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
