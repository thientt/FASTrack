using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FASTrack
{
    /// <summary>
    /// 
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "Username", true);

            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
