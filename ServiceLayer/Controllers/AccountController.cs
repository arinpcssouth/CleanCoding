using BusinessAbstract;
using Model.Authentication;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    
    public class AccountController : ApiController
    {
        IAuthenticationRepository authenticationRepository;
        ISession session;


        public AccountController(IAuthenticationRepository authenticationRepository, ISession  session)
        {
            this.authenticationRepository = authenticationRepository;
            this.session = session;
        }

        [HttpGet]
        public HttpResponseMessage Test()
        {
            return Request.CreateResponse(HttpStatusCode.OK, session.Create(new UserCredentials { Username = "arin", Password = "test" })); 
        }


        [HttpPost]
        public HttpResponseMessage Login([FromBody] UserCredentials credentials)
        {
            var res = session.Create(credentials);
            if (res.Token == new Guid())
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new Exception("Either username or password is wrong."));

            return Request.CreateResponse(HttpStatusCode.OK, res); 
        }


        [HttpGet]
        public HttpResponseMessage GetSession(string token)
        {
            var res = session.GetSessionByToken(token);
            if (res.Token == new Guid())
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new Exception("Invalid Session."));

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }





    }
}