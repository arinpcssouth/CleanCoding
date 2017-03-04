using BusinessAbstract;
using Ninject;
using Ninject.Web.Common;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ServiceLayer
{
    public class WebApiApplication :HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }


     
    }
}
