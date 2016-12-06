using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RopeTest;
using RopeWebApp2.Services;
using RopeWebApp2.Models;

namespace RopeWebApp2.Controllers
{
    public class RopeApiController : ApiController
    {
        public HttpResponseMessage GetTestResults()
        {
            TestModel resultRope = new TestModel(); 
            //InsertService insertService = new InsertService();
            //insertService.ReadFiles();
            //insertService.PrependToLargeStructures(50, 1);
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultRope = testService.FillLargeStructures(5);
            return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        }
    }
}
