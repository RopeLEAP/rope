using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    public class FillService
    {
        // This repeatedly (* iterations) fills a data structure with a copy of war and peace, and tracks in milliseconds how long it takes for each fill to occur; the structures are recreated at each iteration
        // variables to set iterations and track times
        public int replications;
        public int iterations;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contents
        string stringShort;
        string stringLong;
        // path and reader for file I/O
        string shortFilePath = @"c:\repos\files\foxText.txt";
        string longFilePath = @"c:\repos\files\warandpeace.txt";
        // set metadata information
        public string titleMethod = "Fill empty data structures a copy of War and Peace; repeat n (iterations) number of times";
        public string titleStructure;
        //public string exportString;
        public string json;
        // create an enumerable structure of the long string
        public char[] newArray;
        public List<string> lines = new List<string>();
        string jsonLinesSB = "";
        string jsonLinesBL = "";
        string jsonLinesR = "";

        // Make the filled structures available to other tests
        public StringBuilder builderLarge;
        public BigList<char> biglistLarge;
        public Rope.Rope<char> ropeLarge;

        // Get an average time for the fills
        public double averageSB;
        public double averageBL;
        public double averageR;

        public void ReadFiles()
        {
            using (StreamReader readShortFile = new StreamReader(shortFilePath))
            {
                // read in small string file; create data structures to be tested
                stringShort = File.ReadAllText(shortFilePath);
            }
            using (StreamReader readLongFile = new StreamReader(longFilePath))
            {
                // read in long string file; create data structures to be tested
                stringLong = File.ReadAllText(longFilePath);
            }
        }

        public void FillLargeStructures(int newIterations)
        {
            iterations = newIterations;
            // timer variables
            Stopwatch sw = new Stopwatch();
            double builderFill = 0;
            double biglistFill = 0;
            double ropeFill = 0;

            // memory variables
            double memStart = 0;
            double memEnd = 0;
            double builderMem = 0;
            double biglistMem = 0;
            double ropeMem = 0;

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

                // new data structure test
                //Data newDataExport = new RopeTest.Data(i, builderFill, builderMem);
                //Test newTestExport = new RopeTest.Test(replications, titleStructure, titleMethod, newDataExport);

                if (jsonLinesSB == "")
                {
                    jsonLinesSB = json;
                }
                else
                {
                    jsonLinesSB = jsonLinesSB + ", " + json;
                }
            }

            // metadata information
            titleStructure = "BigList";
            // fill biglist
            for (int i = 1; i < (int)iterations + 1; i++)
            {
                
                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                biglistLarge = new BigList<char>(newArray);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                biglistMem = memEnd - memStart;
                biglistFill = sw.ElapsedMilliseconds;
                averageBL += averageBL;
                // Manual json build
                Test dataExport = new Test(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);

                // new data structure test
                //Data newDataExport = new RopeTest.Data(i, builderFill, builderMem);
                //Test newTestExport = new RopeTest.Test(replications, titleStructure, titleMethod, newDataExport);

                if (jsonLinesBL == "")
                {
                    jsonLinesBL = json;
                }
                else
                {
                    jsonLinesBL = jsonLinesBL + ", " + json;
                }
            }

            // metadata information
            titleStructure = "Rope";
            // fill rope
            for (int i = 1; i < (int)iterations + 1; i++)
            {
                memStart = GC.GetTotalMemory(false);
                sw.Start();
                ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                ropeMem = memEnd - memStart;
                ropeFill = sw.ElapsedMilliseconds;
                averageR += averageR;
                //Manual json build
                Test dataExport = new Test(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);

                // new data structure test
                //Data newDataExport = new RopeTest.Data(i, builderFill, builderMem);
                //Test newTestExport = new RopeTest.Test(replications, titleStructure, titleMethod, newDataExport);

                if (jsonLinesR == "")
                {
                    jsonLinesR = json;
                }
                else
                {
                    jsonLinesR = jsonLinesR + ", " + json;
                }
            }
            // append brackets
            jsonLinesR = "[" + jsonLinesR + "]";
            jsonLinesSB = "[" + jsonLinesSB + "]";
            jsonLinesBL = "[" + jsonLinesBL + "]";

            // write to files
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\FillResultsSB.txt"))         
            {
                writeResults.WriteLine(jsonLinesSB);
            }
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\FillResultsBL.txt"))
            {
                writeResults.WriteLine(jsonLinesBL);
            }
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\FillResultsR.txt"))
            {
                writeResults.WriteLine(jsonLinesR);
            }

        }
        // methods to call individual results
        public string GetJsonSB()
        {
            return jsonLinesSB;
        }
        public string GetJsonBL()
        {
            return jsonLinesBL;
        }
        public string GetJsonR()
        {
            return jsonLinesR;
        }

        // methods to return averages
        public double GetAverageSB()
        {
            return averageSB / iterations;
        }
        public double GetAverageBL()
        {
            return averageBL / iterations;
        }
        public double GetAverageR()
        {
            return averageR / iterations;
        }
    }
}
