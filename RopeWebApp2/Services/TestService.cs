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
        // create an enumerable structure of the long string
        public string[] newArray;
        public void ReadFiles()
        {
            using (StreamReader readLongFile = new StreamReader(longFilePath))
            {
                // read in long string file; create data structures to be tested
                stringLong = File.ReadAllText(longFilePath);
            }
            newArray = stringLong.Split(" ".ToCharArray());
        }
 
        // Make the filled structures available to other tests
        public StringBuilder builderLarge;
        public BigList<string> biglistLarge;
        public Rope.Rope<string> ropeLarge;

        // TestModel and TestDataModel are the models for the json object export
        List<TestDataModel> newTestDataModel = new List<TestDataModel>();
        TestModel newTestModel = new TestModel();
        

        // Fill tests
        public TestModel FillTest(int newIterations, string structureName)
        {
            ReadFiles();
            for (int i = 1; i < newIterations + 1; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);

                switch (structureName)
                {
                    case "StringBuilder":
                        newTestModel.title = "StringBuilder";
                        newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");
                        sw.Start();
                        builderLarge = new StringBuilder(stringLong);
                        sw.Stop();
                        break;
                    case "BigList":
                        newTestModel.title = "BigList";
                        newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");
                        sw.Start();
                        biglistLarge = new BigList<string>(newArray);
                        sw.Stop();
                        break;
                    case "Rope":
                        newTestModel.title = "Rope";
                        newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");
                        sw.Start();
                        ropeLarge = new Rope.Rope<string>(newArray, 0, newArray.Length);
                        sw.Stop();
                        break;
                }

                memEnd = GC.GetTotalMemory(false);

                TestDataModel newTestData = new TestDataModel { id = i, memory = (memEnd - memStart), time = sw.ElapsedTicks  };

                // Gets sum of time and memory
                averageTime += newTestData.time;
                averageMemory += newTestData.memory;

                newTestDataModel.Add(newTestData);
                sw.Reset();

            }
            newTestModel.averageTime = averageTime / newIterations;
            newTestModel.averageMemory = averageMemory / newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }

        // Prepend tests
        public TestModel PrependTest(int newIterations, string structureName)
        {
            ReadFiles();
            long memStart = 0, memEnd = 0;

            for (int i = 1; i < newIterations + 1; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);

                switch (structureName)
                {
                    case "StringBuilder":
                        newTestModel.title = "StringBuilder";
                        newTestModel.method = ($"Prepend a copy of War and Peace into data structure; repeat {newIterations} times");
                        builderLarge = new StringBuilder();
                        sw.Start();
                        builderLarge.Insert(0, stringLong);
                        sw.Stop();
                        break;
                    case "BigList":
                        newTestModel.title = "BigList";
                        newTestModel.method = ($"Prepend a copy of War and Peace into data structure; repeat {newIterations} times");
                        biglistLarge = new BigList<string>();
                        sw.Start();
                        biglistLarge.Insert(0, stringLong);
                        sw.Stop();
                        break;
                    case "Rope":
                        newTestModel.title = "Rope";
                        newTestModel.method = ($"Prepend a copy of War and Peace into data structure; repeat {newIterations} times");
                        ropeLarge = new Rope.Rope<string>(newArray, 0, newArray.Length);
                        sw.Start();
                        ropeLarge.AddRange(newArray, 0, newArray.Length);
                        sw.Stop();
                        break;
                }

                memEnd = GC.GetTotalMemory(false);

                TestDataModel newTestData = new TestDataModel { id = i, memory = (memEnd - memStart), time = sw.ElapsedTicks };

                // Gets sum of time and memory
                averageTime += newTestData.time;
                averageMemory += newTestData.memory;

                newTestDataModel.Add(newTestData);
                sw.Reset();

            }
            newTestModel.averageTime = averageTime / newIterations;
            newTestModel.averageMemory = averageMemory / newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }

        // Insert in middle of structure test
        public TestModel MidInsertTest(int newIterations, string structureName)
        {
            ReadFiles();
            long memStart = 0, memEnd = 0;

            for (int i = 1; i < newIterations + 1; i++)
            {
                // get pre-fill memory
                memStart = GC.GetTotalMemory(true);

                switch (structureName)
                {
                    case "StringBuilder":
                        newTestModel.title = "StringBuilder";
                        newTestModel.method = ($"Insert a copy of War and Peace into middle of data structure; repeat {newIterations} times");
                        builderLarge = new StringBuilder();
                        sw.Start();
                        builderLarge.Insert(builderLarge.Length/2, stringLong);
                        sw.Stop();
                        break;
                    case "BigList":
                        newTestModel.title = "BigList";
                        newTestModel.method = ($"Insert a copy of War and Peace into middle of data structure; repeat {newIterations} times");
                        biglistLarge = new BigList<string>();
                        sw.Start();
                        biglistLarge.Insert(biglistLarge.Count/2, stringLong);
                        sw.Stop();
                        break;
                    case "Rope":
                        newTestModel.title = "Rope";
                        newTestModel.method = ($"Insert a copy of War and Peace into middle of data structure; repeat {newIterations} times");
                        ropeLarge = new Rope.Rope<string>(); 
                        sw.Start();
                        ropeLarge.AddRange(newArray, ropeLarge.Length/2, newArray.Length);
                        sw.Stop();
                        break;
                }

                memEnd = GC.GetTotalMemory(false);

                TestDataModel newTestData = new TestDataModel { id = i, memory = (memEnd - memStart), time = sw.ElapsedTicks };

                // Gets sum of time and memory
                averageTime += newTestData.time;
                averageMemory += newTestData.memory;

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

        public TestModel AppendTest(int newIterations, string structureName)
        {
            // Function that read in the file(s) to test.
            ReadFiles();

            // Initialize variables that will store memory at 0.
            long memStart = 0;
            long memEnd = 0;

            // Appends a file to the specified data structure i number of times.
            for (int i = 1; i < newIterations + 1; i++)
            {
                // Get pre-operation memory.
                memStart = GC.GetTotalMemory(true);

                switch (structureName)
                {

                    // Appends a rope repeatedly to another rope.
                    case "Rope":
                        newTestModel.title = "Rope";
                        newTestModel.method = ($"Append a copy of War and Peace to the end of the data structure; repeat {newIterations} times");
                        ropeLarge = new Rope.Rope<string>();
                        sw.Start();
                        ropeLarge.AddRange(newArray, ropeLarge.Length, newArray.Length);
                        sw.Stop();
                        break;

                    // Appends a string repeatedly to a stringbuilder.
                    case "StringBuilder":
                        newTestModel.title = "StringBuilder";
                        newTestModel.method = ($"Append a copy of War and Peace to the end of the data structure; repeat {newIterations} times");
                        builderLarge = new StringBuilder();
                        sw.Start();
                        builderLarge.Append(stringLong);
                        sw.Stop();
                        break;

                    case "BigList":
                        newTestModel.title = "BigList";
                        newTestModel.method = ($"Append a copy of War and Peace to the end of the data structure; repeat {newIterations} times");
                        biglistLarge = new BigList<string>();
                        sw.Start();
                        //foreach (string letter in newArray) Don't understanf why foreach loop is here...
                        //{
                            biglistLarge.Add(stringLong);
                        //}
                        sw.Stop();
                        break;     
                }

                //Get Memory post operations.
                memEnd = GC.GetTotalMemory(false);

                TestDataModel newTestData = new TestDataModel { id = i, memory = (memEnd - memStart), time = sw.ElapsedTicks };

                // Gets sum of time and memory
                averageTime += newTestData.time;
                averageMemory += newTestData.memory;

                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
            newTestModel.averageTime = averageTime / newIterations;
            newTestModel.averageMemory = averageMemory / newIterations;
            newTestModel.data = newTestDataModel;
            return newTestModel;
        }

        // Concat rope vs string?  

        /*  case "String":
              newTestModel.title = "StringBuilder";
              newTestModel.method = ($"Insert a copy of War and Peace into middle of data structure; repeat {newIterations} times");
              builderLarge = new StringBuilder();
              sw.Start();
              builderLarge.Insert(builderLarge.Length / 2, stringLong);
              sw.Stop();
              break;s
              */
    }
}