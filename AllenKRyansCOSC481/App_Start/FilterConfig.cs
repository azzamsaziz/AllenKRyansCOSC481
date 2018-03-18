using System.Web;
using System.Web.Mvc;

namespace AllenKRyansCOSC481
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
