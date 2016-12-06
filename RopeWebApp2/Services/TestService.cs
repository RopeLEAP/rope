using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using RopeWebApp2.Models;
using System.IO;
using Wintellect.PowerCollections;

namespace RopeWebApp2.Services
{
    public class TestService
    {
        // This class repeatedly (* iterations) fills/inserts/concats data structures using a copy of war and peace, and tracks in ellapsed ticks how long it takes for each iteration to occur. Memory allocation readings are taken before and after each iteration.
        // variables to set iterations and track times
        public int replications;
        public int iterations;
        Stopwatch sw = new Stopwatch();
        // memory variables
        public long memStart = 0;
        public long memEnd = 0;
        public long averageTime;
        public long averageMemory;
        // variables to hold file contents
        static string stringLong;
        // path and reader for file I/O
        string longFilePath = @"c:\repos\files\warandpeace.txt";
        // set metadata information
        public string titleStructure;
        // create an enumerable structure to hold the long string
        public char[] newArray;
        public List<string> lines = new List<string>();

        public void ReadFiles()
        {
            using (StreamReader readLongFile = new StreamReader(longFilePath))
            {
                // read in long string file; create data structures to be tested
                stringLong = File.ReadAllText(longFilePath);
            }
        }

        // Make the filled structures available to other tests
        public StringBuilder builderLarge;
        public BigList<char> biglistLarge;
        public Rope.Rope<char> ropeLarge;

        // TestModel and TestDataModel are the models for the json object export
        List<TestDataModel> newTestDataModel = new List<TestDataModel>();
        TestModel newTestModel = new TestModel();

        public TestModel SBFillTest(int newIterations)
        {
            // A test that fills the data structure with the text of war and peace N (newIterations) times, clearing the structure between each fill
            // --------------- First data structure: StringBuilder
            // metadata information
            newTestModel.title = "StringBuilder";
            newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");

            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);
                // start timer
                sw.Start();
                builderLarge = new StringBuilder(stringLong);
                sw.Stop();

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedTicks;
                TimeSpan ts = sw.Elapsed;
                //newTestData.time = ts.Milliseconds;
                averageMemory += averageMemory;
                            
                newTestData.id = i;
                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
            newTestModel.averageTime = averageTime/newIterations;
            newTestModel.averageMemory = averageMemory/newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }
        
        public TestModel BLFillTest(int newIterations)
        {
            // A test that fills the data structure with the text of war and peace N (newIterations) times, clearing the structure between each fill
            // --------------- Second data structure: BigList
            // metadata information
            newTestModel.title = "BigList";
            newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");

            // create an enumerable structure of the long string, required for the Rope  and BigList constructor
            newArray = stringLong.ToCharArray();

            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);
                // start timer
                sw.Start();
                biglistLarge = new BigList<char>(newArray);
                sw.Stop();

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedTicks;
                averageTime += averageTime;
                averageMemory += averageMemory;

                newTestData.id = i;
                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
            newTestModel.averageTime = averageTime / newIterations;
            newTestModel.averageMemory = averageMemory / newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }

        public TestModel RopeFillTest(int newIterations)
        {
            // A test that fills the data structure with the text of war and peace N (newIterations) times, clearing the structure between each fill
            // --------------- Third data structure: Rope
            // metadata information
            newTestModel.title = "Rope";
            newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");

            // create an enumerable structure of the long string, required for the Rope  and BigList constructor
            newArray = stringLong.ToCharArray();

            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);
                // start timer
                sw.Start();
                ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
                sw.Stop();

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedTicks;
                averageTime += averageTime;
                averageMemory += averageMemory;

                newTestData.id = i;
                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
            newTestModel.averageTime = averageTime / newIterations;
            newTestModel.averageMemory = averageMemory / newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }
        // David - do we need this?
        public TestModel SBInsert()
        {
            TestModel data = new TestModel();
            int counter = 0;
            for (int i = 0; i < 101; i++)
            {
                data.id = counter;
                data.title = "test title";
                TestDataModel tests = new TestDataModel();
            }
            return data;
        }

    }
}