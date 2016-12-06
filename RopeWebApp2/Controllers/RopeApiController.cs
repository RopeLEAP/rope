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
        // Run and return stringbuilder tests
        public HttpResponseMessage GetSBTestResults()
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

        //// Run and return BigList tests
        //public HttpResponseMessage GetBLTestResults()
        //{
        //    TestModel resultBL = new TestModel();
        //    //InsertService insertService = new InsertService();
        //    //insertService.ReadFiles();
        //    //insertService.PrependToLargeStructures(50, 1);
        //    TestService testService = new Services.TestService();
        //    testService.ReadFiles();
        //    resultBL = testService.BLFillTest(5);
        //    return Request.CreateResponse(HttpStatusCode.OK, resultBL);
        //}

        //// Run and return Rope tests
        //public HttpResponseMessage GetRTestResults()
        //{
        //    TestModel resultRope = new TestModel();
        //    //InsertService insertService = new InsertService();
        //    //insertService.ReadFiles();
        //    //insertService.PrependToLargeStructures(50, 1);
        //    TestService testService = new Services.TestService();
        //    testService.ReadFiles();
        //    resultRope = testService.RopeFillTest(5);
        //    return Request.CreateResponse(HttpStatusCode.OK, resultRope);
        //}
    }
}
