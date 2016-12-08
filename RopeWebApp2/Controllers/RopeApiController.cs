using System.Net;
using System.Net.Http;
using System.Web.Http;
using RopeWebApp2.Services;
using RopeWebApp2.Models;

namespace RopeWebApp2.Controllers
{
    public class RopeApiController : ApiController
    {
        public HttpResponseMessage GetRopeFillTestResults(int iterations)
        {
            TestModel resultRope = new TestModel();
            TestService testService = new Services.TestService();
            //testService.ReadFiles();
            resultRope = testService.FillTest(iterations, "Rope");
            return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        }

        public HttpResponseMessage GetRopePrependTestResults(int iterations)
        {
            TestModel resultRope = new TestModel();
            TestService testService = new Services.TestService();
            //testService.ReadFiles();
            resultRope = testService.PrependTest(iterations, "Rope");
            return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        }

        public HttpResponseMessage GetRopeMidInsertTestResults(int iterations)
        {
            TestModel resultRope = new TestModel();
            TestService testService = new Services.TestService();
            //testService.ReadFiles();
            resultRope = testService.MidInsertTest(iterations, "Rope");
            return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        }

        // This method calls the rope append test and sends results.
        public HttpResponseMessage GetRopeAppendTestResults(int iterations)
        {
            
            TestModel resultRope = new TestModel();
            TestService testService = new TestService();
            resultRope = testService.AppendTest(iterations, "Rope");
            return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        }

    }
}
