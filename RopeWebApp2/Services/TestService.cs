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
        public int replications;                                            //NOT USED
        public int iterations;                                           //NOT USED
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
        public string titleStructure;                                   //NOT USED
        // create an enumerable structure of the long string
        public char[] newArray;
        public List<string> lines = new List<string>();                     //NOT USED

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
            return FillTest(newIterations, "StringBuilder");
        }
        
        public TestModel BLFillTest(int newIterations)
        {
            return FillTest(newIterations, "BigList");
        }

        public TestModel RopeFillTest(int newIterations)
        {

            return FillTest(newIterations, "Rope");
        }

<<<<<<< HEAD
        public TestModel BLPrependTest(int newIterations)
        {
            // A test that fills the data structure with the text of war and peace N (newIterations) times, clearing the structure between each fill
            // --------------- Second data structure: BigList
            // metadata information
            newTestModel.title = "BigList";
            newTestModel.method = ($"Insert copy of War and Peace at start of structure; repeat {newIterations} times");

            // create an enumerable structure of the long string, required for the Rope and BigList constructor
            newArray = stringLong.ToCharArray();
=======
        public TestModel FillTest(int newIterations, string structureName)
        {
            long memStart = 0, memEnd = 0;
>>>>>>> 77c712680485ea8580a0f3f60dcddc1445f3538b

            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

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
                        biglistLarge = new BigList<char>(newArray);
                        sw.Stop();
                        break;
                    case "Rope":
                        newTestModel.title = "Rope";
                        newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");
                        sw.Start();
                        ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
                        sw.Stop();
                        break;
                }

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedTicks;
                averageTime += newTestData.time;
                averageMemory += newTestData.memory;

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

        // ---------------------------- LIZ - add your code below here
    }
}