using System.Net;
using System.Net.Http;
using System.Web.Http;
using RopeWebApp2.Services;
using RopeWebApp2.Models;

namespace RopeWebApp2.Controllers
{
    public class StringBuilderApiController : ApiController
    {
        // Run and return stringbuilder tests
        public HttpResponseMessage GetStringBuilderFillTestResults(int iterations)
        {
            TestModel resultSB = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultSB = testService.FillTest(iterations, "StringBuilder");
            return Request.CreateResponse(HttpStatusCode.OK, resultSB);
        }
        public HttpResponseMessage GetStringBuilderPrependTestResults(int iterations)
        {
            TestModel resultSB = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultSB = testService.PrependTest(iterations, "StringBuilder");
            return Request.CreateResponse(HttpStatusCode.OK, resultSB);
        }
        public HttpResponseMessage GetStringBuilderMidInsertTestResults(int iterations)
        {
            TestModel resultSB = new TestModel();
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultSB = testService.MidInsertTest(iterations, "StringBuilder");
            return Request.CreateResponse(HttpStatusCode.OK, resultSB);
        }

        // This method calls the Stringbuilder append test and sends results.
        public HttpResponseMessage GetStringBuilderAppendTestResults(int iterations)
        {
            TestModel resultSB = new TestModel();
            TestService testService = new TestService();
            testService.ReadFiles();
            resultSB = testService.AppendTest(iterations, "StringBuilder");
            return Request.CreateResponse(HttpStatusCode.OK, resultSB);
        }
    }
}
