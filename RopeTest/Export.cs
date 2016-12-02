using System.Collections.Generic;
using Newtonsoft.Json;

namespace RopeTest
{
    class Export
    {
        public string structure { get; set; } // data structure being tested
        public string method { get; set; } // method being tested
        public string methodology { get; set; } // 'how' of test (i.e., 2 insertions / 2 ropes being concatenated to 1 rope / etc.
        public double time { get; set; } // elapsed time in milliseconds
        public double memory { get; set; } // memory change in bytes
        public int replicationId { get; set; } // which replication set this iteration belongs to
        public int testId { get; set; } // which iteration this is

        // each test method will loop through a list of results and each entry in the list will create a json object which will be appended to the of json (string?) 
        public string GetJason(string result)
        {
            string serialized = JsonConvert.SerializeObject(result);
            return serialized;
        }

        /* each object in the list will look like this:
         * {
         *  "Structure": "Rope",
         *  "Method": "Prepend",
         *  "Methodology": "Multiple prepends to existing structure of size x",
         *  "Time": "23",
         *  "Memory": "6432",
         *  "ReplicationId": "1",
         *  "TestId": "34"
         *  }
        */ 
    }
}
