using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    public class SplitTest
    {
        // variables to set iterations and track times
        int operationIts = 1000;
        int collectionIts = 100000;
        Stopwatch sw = new Stopwatch();
        // path and reader for file input
        string inFilePath = @"c:\repos\Rope\foxText.txt";

        public void readSmallFile()
        {
            StreamReader readFile = new StreamReader(inFilePath);
            // read in small string file; create data structures to be tested
            string stringSmall = File.ReadAllText(inFilePath);
            Console.WriteLine(stringSmall.ToString());
            Console.ReadLine();
        }

        public void testStructures()
        {
            
        }

        public void fillStructures()
        {
            StreamReader readFile = new StreamReader(inFilePath);
            // read in small string file; create data structures to be tested
            string stringSmall = File.ReadAllText(inFilePath);
            // Stringbuilder only has append, insert, remove and replace
            StringBuilder builderSmall = new StringBuilder();
            // BigList doesn't have a concat either
            BigList<string> biglistSmall = new BigList<string>();
            // LeapRope<string> leapSmall; -- placeholder for rope structure

            // fill structures with initial instance of string
            builderSmall.Append(stringSmall);
            biglistSmall.Add(stringSmall);

            // build a collection of strings
            sw.Start();
            for (int i = 0; i < collectionIts; i++)
            {
                builderSmall.Append(stringSmall);
            }
            sw.Stop();
            long timeBuilderCollection = sw.ElapsedMilliseconds;

            // test concatenations of structures
            string testString = "";
            sw.Start();
            for (int i = 0; i < operationIts; i++)
            {
                // test of simple string concatenation
                // testString = string.Concat(testString, stringSmall);
                testString = string.Concat(testString, builderSmall[i]); // this returns i chars
            }
            sw.Stop();
            long timeStringConcat = sw.ElapsedMilliseconds;
            // View contents of structures
            Console.WriteLine("String concatenation - " + operationIts + " iterations: " + timeStringConcat + " ms");
            //Console.WriteLine("Stringbuilder contents: " + builderSmall.ToString());
            Console.WriteLine("String contents: " + testString.ToString());
            Console.WriteLine("Collection building - " + collectionIts + " iterations: " + timeBuilderCollection + " ms");
            Console.WriteLine("Stringbuilder length: " + builderSmall.Length);
            Console.WriteLine("Small string length: " + stringSmall.Length + " times stringbuilder: " + (stringSmall.Length * collectionIts));
            Console.ReadLine();
        }

    }
}
