using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    public class FillTest
    {
        // variables to set iterations and track times
        public int replications = 1;
        public double iterations = 10;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contetns
        string stringShort;
        string stringLong;
        // path and reader for file I/O
        string shortFilePath = @"c:\repos\files\foxText.txt";
        string longFilePath = @"c:\repos\files\warandpeace.txt";
        // metadata information
        public string titleMethod = "Initial Fill";
        public string titleStructure;
        public string exportString;
        public string json;
        // create an enumerable structure of the long string
        char[] newArray;
        List<string> lines = new List<string>();
        string jsonLines = "";

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

        public void FillLargeStructures()
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

            // create an enumerable structure of the long string
            newArray = stringLong.ToCharArray();
            

            // time filling of data structures with initial instance of string
            // ---------------------------------------------------------------
            // metadata information
            titleStructure = "StringBuilder";
            // fill stringbuilder
            for (int i = 1; i < (int)iterations + 1; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                StringBuilder builderLarge = new StringBuilder(stringLong);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                builderMem = memEnd - memStart;
                builderFill = sw.ElapsedMilliseconds;
                builderLarge.Clear();
                //GC.Collect();
                Export dataExport = new Export(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);
                if (jsonLines == "")
                {
                    jsonLines = json;
                }
                else
                {
                    jsonLines = jsonLines + ", " + json;
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
                BigList<char> biglistLarge = new BigList<char>(newArray);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                biglistMem = memEnd - memStart;
                biglistFill = sw.ElapsedMilliseconds;
                // GC.Collect();
                Export dataExport = new Export(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);
                if (jsonLines == "")
                {
                    jsonLines = json;
                }
                else
                {
                    jsonLines = jsonLines + ", " + json;
                }
            }

            // metadata information
            titleStructure = "Rope";
            // fill rope
            for (int i = 1; i < (int)iterations + 1; i++)
            {
                memStart = GC.GetTotalMemory(false);
                sw.Start();
                Rope.Rope<char> ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                ropeMem = memEnd - memStart;
                ropeFill = sw.ElapsedMilliseconds;
                //GC.Collect();
                Export dataExport = new Export(replications, titleStructure, titleMethod, "teststringofmethodology", i, builderFill, builderMem);
                json = dataExport.CreateJson(dataExport);
                if (jsonLines == "")
                {
                    jsonLines = json;
                }
                else
                {
                    jsonLines = jsonLines + ", " + json;
                }
            }
            // write results
            jsonLines = "[" + jsonLines + "]";

            // make it available
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\files\FillResults.txt"))
            
            {
                writeResults.WriteLine(jsonLines);
            }

        }
        public string GetJson()
        {
            return jsonLines;
        }
    }
}
