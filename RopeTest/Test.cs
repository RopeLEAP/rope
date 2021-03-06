﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace RopeTest
{
    public class Test
    {
        // title of the test
        public string title { get; set; }
        public string structure { get; set; }
        public string method { get; set; } // method being tested
        public string methodology { get; set; } // 'how' of test (i.e., 2 insertions / 2 ropes being concatenated to 1 rope / etc.
        public double time { get; set; } // elapsed time in milliseconds
        public double memory { get; set; } // memory change in bytes
        public int replicationId { get; set; } // which replication set this iteration belongs to
        public int iterationId { get; set; } // which iteration this is
        public Data data { get; set;  } // the internal data object for json
        List<Test> exportTests = new List<Test>();
        List<object> jsonTests = new List<object>();


        public Test(int _replicationId, string _structure, string _method,  string _methodology, int _iterationId, double _time, double _memory)
        {
            replicationId = _replicationId;
            title = _structure + " " + _method + " Test";
            structure = _structure;
            method = _method;
            methodology = _methodology;
            iterationId = _iterationId;
            time = _time;
            memory = _memory;
            exportTests.Add(this);
        }
        public string GetJson()
        {

            return "";
        }

        public Test(int _replicationId, string _structure, string _method, Data _data)
        {
            replicationId = _replicationId;
            title = _structure + " " + _method + " Test";
            structure = _structure;
            method = _method;
            data = _data;
            exportTests.Add(this);
        }

        public Data GetDataObject(double _iterationId, double _time, double _memory)
        {
            Data newDataObject = new Data(_iterationId, _time, _memory);
            return newDataObject;
        }


        // each test method will loop through a list of results and each entry in the list will create a json object which will be appended to the of json (string?) 
        public string CreateJson(object result)
        {
            string serialized = JsonConvert.SerializeObject(result);
            return serialized;
        }
    }
}
