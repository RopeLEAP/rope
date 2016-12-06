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
        public HttpResponseMessage GetBigListIPrependTestResults(int iterations)
        {
            TestModel resultBL = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultBL = testService.PrependTest(iterations, "BigList");
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }
    }
}
