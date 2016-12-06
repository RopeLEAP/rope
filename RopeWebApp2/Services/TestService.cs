﻿using System;
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
        // This repeatedly (* iterations) fills a data structure with a copy of war and peace, and tracks in milliseconds how long it takes for each fill to occur; the structures are recreated at each iteration
        // variables to set iterations and track times
        public int replications;
        public int iterations;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contents
        static string stringLong;
        // path and reader for file I/O
        string longFilePath = @"c:\repos\files\warandpeace.txt";
        // set metadata information
        public string titleStructure;
        // create an enumerable structure of the long string
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

        // Get an average time for the fills
        public double averageSB;

        List<TestDataModel> newTestDataModel = new List<TestDataModel>();
        TestModel newTestModel = new TestModel();

        public TestModel SBFillTest(int newIterations)
        {
            // A test that fills the data structure with the text of war and peace N (newIterations) times, clearing the structure between each fill
            // --------------- First data structure: StringBuilder
            // metadata information
            newTestModel.title = "StringBuilder";
            newTestModel.method = ($"Fill empty data structures with a copy of War and Peace; repeat {newIterations} times");

            // timer variables
            Stopwatch sw = new Stopwatch();

            // memory variables
            double memStart = 0;
            double memEnd = 0;

            // create an enumerable structure of the long string, required for the Rope constructor
            //newArray = stringLong.ToCharArray();

            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                builderLarge = new StringBuilder(stringLong);
                sw.Stop();

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedMilliseconds;
                averageSB += averageSB;
                
                newTestData.id = i;
                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
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

            // timer variables
            Stopwatch sw = new Stopwatch();

            // memory variables
            double memStart = 0;
            double memEnd = 0;

            // create an enumerable structure of the long string
            newArray = stringLong.ToCharArray();

            // time filling of data structures with a single instance of string
            // ---------------------------------------------------------------
            for (int i = 1; i < newIterations + 1; i++)
            {
                TestDataModel newTestData = new TestDataModel();

                // get pre-fill memory
                memStart = GC.GetTotalMemory(false);
                // start timer
                sw.Start();
                biglistLarge = new BigList<char>(newArray);
                sw.Stop();

                memEnd = GC.GetTotalMemory(false);
                newTestData.memory = memEnd - memStart;
                newTestData.time = sw.ElapsedMilliseconds;
                averageSB += averageSB;

                newTestData.id = i;
                newTestDataModel.Add(newTestData);
                sw.Reset();
            }
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