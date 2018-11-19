using System.Web;
using System.Web.Mvc;

namespace com.udistrital.mcic.informatica.iot.api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
