using System.Net;
using System.Net.Http;
using System.Web.Http;
using RopeWebApp2.Services;
using RopeWebApp2.Models;

namespace RopeWebApp2.Controllers
{
    public class BigListApiController : ApiController
    {
        // Run and return BigList tests
        public HttpResponseMessage GetBigListFillTestResults(int iterations)
        {
            TestModel resultBL = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultBL = testService.FillTest(iterations, "BigList");
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }
        public HttpResponseMessage GetBigListPrependTestResults(int iterations)
        {
            TestModel resultBL = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultBL = testService.PrependTest(iterations, "BigList");
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }
        public HttpResponseMessage GetBigListMidInsertTestResults(int iterations)
        {
            TestModel resultBL = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultBL = testService.MidInsertTest(iterations, "BigList");
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }


        // This method calls the Stringbuilder append test and sends results.
        public HttpResponseMessage GetBigListAppendTestResults(int iterations)
        {
            TestModel resultBL = new TestModel();
            TestService testService = new TestService();
            testService.ReadFiles();
            resultBL = testService.AppendTest(iterations, "BigList");
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }
    }
}
