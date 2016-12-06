using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeTest
{
    abstract public class APerformanceTest
    {
        protected int iterations;

        public APerformanceTest(int iteration)
        {
            iterations = iteration;
        }

        abstract public void Concatenate();
        abstract public void Split();
        abstract public void Prepend();
        abstract public void Fill();
        abstract public void Insert();
        abstract public void Delete();
        abstract public void Search();
        abstract public void Append();

    }
}
