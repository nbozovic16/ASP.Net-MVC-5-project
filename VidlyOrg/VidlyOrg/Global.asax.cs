using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using VidlyOrg.App_Start;

namespace VidlyOrg
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //mapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            //for Api
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
