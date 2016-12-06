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
        public HttpResponseMessage GetBigListFillTestResults()
        {
            TestModel resultBL = new TestModel();
            //InsertService insertService = new InsertService();
            //insertService.ReadFiles();
            //insertService.PrependToLargeStructures(50, 1);
            TestService testService = new Services.TestService();
            testService.ReadFiles();
            resultBL = testService.BLFillTest(5);
            return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        }
    }
}
