﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Diagnostics;
using RopeWebApp2.Models;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeWebApp2.Services
{
    public class AppendTests
    {
       /*
        // Fields to set number of iterations in each test and how many replications. 
        int fNumIterations;
        int fNumReplications;
        string structureName; //For JSON metadata.

        public AppendTests(int numIterations, int numreplications) //print results for each replication?
        {
            fNumReplications = numreplications;
            fNumIterations = numIterations;
        }

        public AppendTests() //Maybe Temporary constructor, for the RopeAPI controller...
        {

        }

        // Filepaths
        string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");
        string foxSentence = "The quick brown fox jumps over the lazy dog."; // Only use big string, this won't be hardcoded for a long time.

        // Rewrite loops so they keep getting bigger!!
        // Create stopwatch. 
        Stopwatch sw = new Stopwatch();

        // Memory variables
        long memStart = 0;
        long memEnd = 0;
        long memUsed = 0;

        // TestModel and TestDataModel are the models for the json object export
        List<TestDataModel> newTestDataModel = new List<TestDataModel>();
        TestModel newTestModel = new TestModel();

        public string json;

        // Method to Concatenate Ropes.
        public void RopeConcatTestCreateRopes()
        {
            // Lists to calculate averages. See if you can declare these once and reset? Don't calculate averages! Try to break!
            
            //List<int> lengths = new List<int>();
            //List<double> memallocs = new List<double>();
            //List<double> runtimes = new List<double>();
            

            // Metadata information.
            structureName = "Rope";

            for (int i = 0; i < fNumReplications; i++)
            {
                for (int j = 0; j < fNumIterations; j++)
                {

                    //TestDataModel newTestData = new TestDataModel();

                    // Get memory pre-operation.
                    memStart = GC.GetTotalMemory(true);

                    //Start stopwatch.
                    sw.Reset();
                    sw.Start();

                    // These should be faster than converting to charArray,
                    //and then you can just read the file in the very beginning 
                    //and not count that in the time & memory!
                    Rope.Rope<string> ropeWarPeace = new Rope.Rope<string>
                        (warPeace.Split(" ".ToCharArray())); //splits on word, can split on sentence too. Might need to go back to char arrays for consistency.
                    Rope.Rope<string> ropeFoxSentence = new Rope.Rope<string>
                        (foxSentence.Split(" ".ToCharArray()));
                    Console.WriteLine(ropeFoxSentence);

                    // Concatenate Ropes.
                    // This is shorter than the others now since it's splitting on words...
                    Rope.Rope<string> ropeConcat = Rope.Rope<string>.Concat(ropeWarPeace, ropeFoxSentence);

                    // Stop timer.
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    //Console.WriteLine("Start {0} End {1}", memStart, memEnd);

                    //Calculate total memory.
                    //memUsed = memEnd - memStart;
                    /*
                    newTestData.id = i;
                    newTestData.memory = memEnd - memStart;
                    newTestData.time = sw.ElapsedTicks;
                    //Console.WriteLine(memUsed);
                    

                    TestDataModel newTestData = new TestDataModel { id = i, memory = (memEnd - memStart), time = sw.ElapsedTicks };

                    //newTestDataModel.Add(newTestData)
                    /*if (jsonLinesSB == "")
                    {
                        jsonLinesSB = json;
                    }
                    else
                    {
                        jsonLinesSB = jsonLinesSB + ", " + json;
                    }
                    //Console.WriteLine(newTestData);

                    // Append values to each list.
                    //lengths.Add(ropeConcat.Length);
                    //memallocs.Add(memUsed);
                    // runtimes.Add(sw.ElapsedTicks);
                    Debug.Write(newTestData);
                }

                // Print averages of ropeConcat.Length, Runtime, for each rep and export to JSON
                // Print time will need to be JSON EXPORT!
               
                Console.WriteLine("Length of new rope: " + lengths.Sum() / lengths.Count() + " words" +
                        "\nRuntime: " + runtimes.Sum() / lengths.Count() + " ms" +
                        "\nMemory used: " + memallocs.Sum() / memallocs.Count() + " bytes");
                
            }
        }
      
        public void StringConcatReadStrings()
        {
            // Lists to calculate averages.
            List<int> lengths = new List<int>();
            List<double> memallocs = new List<double>();
            List<double> runtimes = new List<double>();

            // Metadata information.
            structureName = "String";

            for (int i = 0; i < fNumReplications; i++)
            {
                for (int j = 0; j < fNumIterations; j++)
                {

                    // Get memory pre-operation.
                    memStart = GC.GetTotalMemory(true);

                    // Set Stopwatch.
                    sw.Reset();
                    sw.Start();

                    // Concatenate strings
                    string stringConcat = warPeace + foxSentence;

                    // Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    Console.WriteLine("Start {0} End {1}", memStart, memEnd);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;
                    //Console.WriteLine(memUsed);

                    // Append values to each list.
                    lengths.Add(stringConcat.Length);
                    memallocs.Add(memUsed);
                    runtimes.Add(sw.ElapsedTicks);
                }
                // Print results.
                Console.WriteLine("Length of new string: " + lengths.Sum() / lengths.Count() + " characters" +
                            "\nRuntime: " + runtimes.Sum() / lengths.Count() + " ms" +
                            "\nMemory used: " + memallocs.Sum() / memallocs.Count() + " bytes");
            }
        }

        //Concat with StringBuilder.
        public void StringBuilderConcatReadstrings()
        {

            //Lists to calculate averages.
            List<int> lengths = new List<int>();
            List<double> memallocs = new List<double>();
            List<double> runtimes = new List<double>();

            // Metadata information.
            structureName = "StringBuilder";

            for (int i = 0; i < fNumReplications; i++)
            {
                for (int j = 0; j < fNumIterations; j++)
                {

                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(true);

                    //Set Stopwatch.
                    sw.Reset();
                    sw.Start();

                    // Create new stringbuilder.
                    StringBuilder combinedSB = new StringBuilder(warPeace);

                    // "concatenate" strings using .Append method.
                    combinedSB.Append(foxSentence);

                    //Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    Console.WriteLine("Start {0} End {1}", memStart, memEnd);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;
                    //Console.WriteLine(memUsed);

                    // Append values to each list.
                    lengths.Add(combinedSB.Length);
                    memallocs.Add(memUsed);
                    runtimes.Add(sw.ElapsedMilliseconds);

                }
                //Print time
                Console.WriteLine("Length of new stringBuilder: " + lengths.Sum() / lengths.Count() + " characters" +
                        "\nRuntime: " + runtimes.Sum() / lengths.Count() + " ms" +
                        "\nMemory used: " + memallocs.Sum() / memallocs.Count() + " bytes");
            }
        }

        //Concat with Biglist
        public void BigListConcatReadStrings()
        {
            //Lists to calculate averages.
            List<int> lengths = new List<int>();
            List<double> memallocs = new List<double>();
            List<double> runtimes = new List<double>();

            // Metadata information.
            structureName = "BigList";

            for (int i = 0; i < fNumReplications; i++)
            {
                for (int j = 0; j < fNumIterations; j++)
                {
                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(true);

                    // Start stopwatch.
                    sw.Reset();
                    sw.Start();

                    // Create new BigList
                    BigList<char> combinedBL = new BigList<char>(warPeace);

                    //Convert foxSentence to charArray and .Add foxlist to BigList for concat.
                    combinedBL.AddRange(foxSentence);

                    //Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    Console.WriteLine("Start {0} End {1}", memStart, memEnd);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;
                    //Console.WriteLine(memUsed);

                    // Append values to each list.
                    lengths.Add(combinedBL.Count);
                    memallocs.Add(memUsed);
                    runtimes.Add(sw.ElapsedMilliseconds);

                }
                // Print results
                Console.WriteLine("Length of new BigList: " + lengths.Sum() / lengths.Count() + " characters" +
                        "\nRuntime: " + runtimes.Sum() / lengths.Count() + " ms" +
                        "\nMemory used: " + memallocs.Sum() / memallocs.Count() + " bytes");
            }

            // Read Results.
            Console.ReadLine();
        }
       */
    }
}