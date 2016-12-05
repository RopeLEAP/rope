using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RopeTest;

namespace RopeWebApp2.Controllers
{
    public class RopeApiController : ApiController
    {
        public void GetTestResults()
        {
            string resultRope;
            InsertService insertService = new InsertService();
            insertService.ReadFiles();
            insertService.PrependToLargeStructures(50, 1);
            resultRope = insertService.GetJsonR();
        }
    }
}
