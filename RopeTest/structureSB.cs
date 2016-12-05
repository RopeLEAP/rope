using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RopeTest
{
    public class structureSB : RunTests
    {
        // This class repeatedly (* iterations) fills a data structure with a copy of war and peace, and tracks in milliseconds how long it takes for each fill to occur; the structures are recreated at each iteration

        // variables to set iterations and track times
        public int replications;
        public int iterations;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contents
        public string stringLong;
        // set metadata information
        public string titleMethod = "Fill empty data structures a copy of War and Peace; repeat n (iterations) number of times";
        public string titleStructure;
        //public string exportString;
        public string json;
        // create an enumerable structure of the long string
        public char[] newArray;
        public List<string> lines = new List<string>();
        string jsonLinesSB = "";

        
        
        // Make the filled structures available to other tests
        public StringBuilder builderLarge;

        // Get an average time for the fills
        public double averageSB;

        // Read in files
        FileReader readTestFile = new FileReader();

        public override string RunTest(int newIterations)
        {
            iterations = newIterations;
            // timer variables
            Stopwatch sw = new Stopwatch();
            double builderFill = 0;

            // memory variables
            double memStart = 0;
            double memEnd = 0;
            double builderMem = 0;

            // create an enumerable structure of the long string
            newArray = stringLong.ToCharArray();


            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            // metadata information
            titleStructure = "StringBuilder";
            // fill stringbuilder
            for (int i = 1; i < iterations + 1; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                builderLarge = new StringBuilder(stringLong);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                builderMem = memEnd - memStart;
                builderFill = sw.ElapsedMilliseconds;
                averageSB += averageSB;
                // Manual json build
                Test dataExport = new Test(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);

                if (jsonLinesSB == "")
                {
                    jsonLinesSB = json;
                }
                else
                {
                    jsonLinesSB = jsonLinesSB + ", " + json;
                }
            }
            return jsonLinesSB;
        }
    }
}
