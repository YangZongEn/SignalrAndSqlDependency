using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProgressBarTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //SqlDependency.Start(@"Data Source=.;Initial Catalog=TEST;integrated security=SSPI");
            //SqlDependency.Start(ConfigurationManager.ConnectionStrings["NotificationTestEntities"].ConnectionString);
            SqlDependency.Start(@"Data Source=192.168.100.163;Initial Catalog=NotificationTest;user id=sa;password=Aa123456;");
        }

        //protected void Application_End()
        //{
        //                      Initial Catalog = MyDb; Data Source = MyServer; Integrated Security = SSPI;
        //    SqlDependency.Stop("Data Source=localhost;Initial Catalog=TEST;Integrated Security=True");
        //}
    }
}
