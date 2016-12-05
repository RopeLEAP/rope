using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    class InsertService
    {
        // This class calls FillService and runs those times tests; then takes the last iteration of the fill service data structures and repeatedly inserts another copy of War and Peace into the structure at the given position a given number of times (iterations)
        Stopwatch sw = new Stopwatch();
        // variables to hold file contents
        string stringShort;
        string stringLong;
        // path and reader for file I/O
        string shortFilePath = @"c:\repos\files\foxText.txt";
        string longFilePath = @"c:\repos\files\warandpeace.txt";
        // metadata information
        public string titleMethod = "Insert War and Peace at beginning of data structures the given number of times - structures which have been instantiated with a single copy of War and Peace.";
        public string titleStructure;
        //public string exportString;
        public string json;
        // create an enumerable structure of the long string
        public char[] newArray;
        List<string> lines = new List<string>();
        string jsonLinesSB = "";
        string jsonLinesBL = "";
        string jsonLinesR = "";

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

        public void PrependToLargeStructures(int replications, int iterations)
        {
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

            // create an enumerable structure of the long string as feed for rope
            newArray = stringLong.ToCharArray();

            // Call the fill service to create large structures
            FillService insertFillService = new FillService();
            insertFillService.ReadFiles();
            insertFillService.FillLargeStructures(iterations);

            StringBuilder builderLarge = insertFillService.builderLarge;
            BigList<char> biglistLarge = insertFillService.biglistLarge;
            Rope.Rope<char> ropeLarge = insertFillService.ropeLarge;

            // time insertion of string into structures with a single copy of war and peace
            // ---------------------------------------------------------------
            // metadata information
            titleStructure = "StringBuilder";
            // fill stringbuilder
            for (int i = 0; i < replications; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                builderLarge.Insert(0, stringLong);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                builderMem = memEnd - memStart;
                builderFill = sw.ElapsedMilliseconds;
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

            // metadata information
            titleStructure = "BigList";
            // fill biglist
            for (int i = 0; i < replications; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                foreach(char letter in newArray)
                {
                    biglistLarge.Insert(0, letter);
                }               
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                biglistMem = memEnd - memStart;
                biglistFill = sw.ElapsedMilliseconds;
                // Manual json build
                Test dataExport = new Test(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);
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
            // insert into rope
            for (int i = 0; i < replications; i++)
            {
                memStart = GC.GetTotalMemory(false);
                sw.Start();
                ropeLarge.AddRange(newArray, 0, newArray.Length);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                ropeMem = memEnd - memStart;
                ropeFill = sw.ElapsedMilliseconds;
                //Manual json build
                Test dataExport = new Test(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);
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
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\InsertResultsSB.txt"))
            {
                writeResults.WriteLine(jsonLinesSB);
            }
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\InsertResultsBL.txt"))
            {
                writeResults.WriteLine(jsonLinesBL);
            }
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\InsertResultsR.txt"))
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
    }
}
