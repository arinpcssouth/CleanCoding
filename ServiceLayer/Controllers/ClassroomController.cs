using BusinessAbstract.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceLayer.Controllers.ActionFilters;
using BusinessAbstract;

namespace ServiceLayer.Controllers
{
    public class ClassroomController : ApiController
    {
        IClassroomFactory classroomFactory;
        ISession session;

        public ClassroomController(IClassroomFactory classroomFactory, ISession session)
        {
            this.classroomFactory = classroomFactory;
            this.session = session;
        }


        [HttpGet]
        [ValidateToken]
        public HttpResponseMessage GetClassrooms()
        {
            var res = classroomFactory.GenerateClassrooms();
          
            return Request.CreateResponse(HttpStatusCode.OK, res);
        }



    }
}
