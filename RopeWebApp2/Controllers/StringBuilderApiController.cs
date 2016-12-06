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
        public HttpResponseMessage GetStringBuilderFillTestResults()
        {
            TestModel resultSB = new TestModel();
            //InsertService insertService = new InsertService();
            //insertService.ReadFiles();
            //insertService.PrependToLargeStructures(50, 1);
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultSB = testService.SBFillTest(5);
            return Request.CreateResponse(HttpStatusCode.OK, resultSB);
        }
    }
}
