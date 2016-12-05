using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RopeWebApp.Controllers
{
    public class RopeApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetTestResults()
        {
            string message = "success";
            Console.WriteLine(message);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
