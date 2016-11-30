using System;
using System.IO;

namespace RopeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------- this section contains function calls to the fill and insert test classes (sid) ----------------------- //
            FillTest fillTest = new FillTest();
            fillTest.ReadFiles();
            fillTest.FillLargeStructures();
            Console.WriteLine("Done! File is FillResults.txt in the repos/repo directory.");

            InsertTest insertTest = new InsertTest();
            insertTest.ReadFiles();
            insertTest.PrependToLargeStructures();
            Console.WriteLine("Done! File is InsertResults.txt in the repos/repo directory.");


            Console.ReadLine();

            // ----------------------------- this section contains function calls to the concat test class (liz) ---------------------- //



            // ----------------------------- this section contains function calls to the append test class (kwame) -------------------- //

        }
    }
}
