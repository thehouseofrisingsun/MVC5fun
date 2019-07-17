using System.Web;
using System.Web.Mvc;

namespace MVC5Fund
{
    public partial class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
