using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeTest
{
    public class Data
    {
        public double iterationId { get; set; }
        public double time { get; set; }
        public double memory { get; set; }

        public Data(double _iterationId, double _time, double _memory)
        {
            iterationId = _iterationId;
            time = _time;
            memory = _memory;
        }
    }
}
