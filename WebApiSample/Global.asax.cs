﻿using System.Web.Http;
using System.Web.Mvc;

namespace WebApiSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            MediaTypeFormatterConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}