using BusinessAbstract;
using Ninject.Web.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ServiceLayer.Controllers.ActionFilters
{

    //see NinjectWebCommon.cs for more details. There is a reason this empty class i shere. 
    public class ValidateTokenAttribute : ActionFilterAttribute
    {

    }

    public class ValidateTokenFilter : AbstractActionFilter
    {
        public override bool AllowMultiple { get { return true; } }

        
        
        ISession session { get; set; }


        public ValidateTokenFilter(ISession session)
        {
            this.session = session;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string headerToken = "";
            try
            {
                headerToken = actionContext.Request.Headers.GetValues("Token").FirstOrDefault();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            if(session.GetSessionByToken(headerToken).Token == new Guid())
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}