using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RopeWebApp2.Models
{
    public class TestModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string structure { get; set; }
        public string method { get; set; }
        public List<TestDataModel> data { get; set; }
    }
}