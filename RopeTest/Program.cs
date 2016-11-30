using System;
using System.IO;

namespace RopeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------- this section contains function calls to the split test class (sid) ----------------------- //
            /*SplitTest splitTest = new SplitTest();
            splitTest.readFiles();
            splitTest.fillStructures();

            // test a rope
            Console.ReadLine();*/


            // ----------------------------- this section contains function calls to the concat test class (liz) ---------------------- //

            ConcatTest firstConcatTest = new ConcatTest();
            firstConcatTest.RopeConcatTestCreateRopes();

            // ----------------------------- this section contains function calls to the append test class (kwame) -------------------- //

        }
    }
}
