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
        int operationIts = 10;
        int collectionIts = 10;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contetns
        string stringShort;
        string stringLong;
        // path and reader for file input
        string shortFilePath = @"c:\repos\Rope\foxText.txt";
        string longFilePath = @"c:\repos\Rope\warandpeace.txt";

        public void readFiles()
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

        public void fillStructures()
        {
            // fill with small string
            // Stringbuilder only has append, insert, remove and replace
            StringBuilder builderSmall = new StringBuilder();
            // BigList doesn't have a concat either
            BigList<string> biglistSmall = new BigList<string>();
            // Local rope structure
            Rope.Rope<string> ropeSmall = new Rope.Rope<string>();
            // fill structures with initial instance of string
            builderSmall.Append(stringShort);
            biglistSmall.Add(stringShort);
            ropeSmall.Add(stringShort);

            // fill with large string
            // Stringbuilder only has append, insert, remove and replace
            StringBuilder builderLarge = new StringBuilder();
            // BigList doesn't have a concat either
            BigList<string> biglistLarge = new BigList<string>();
            // Local rope structure
            
            // fill structures with initial instance of string
            builderLarge.Append(stringLong);
            biglistLarge.Add(stringLong);
            char[] newArray = stringLong.ToCharArray();
            Rope.Rope<char> ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
            Console.WriteLine("Hey Hey Hello");

            //// build a collection of strings
            //sw.Start();
            //for (int i = 0; i < collectionIts; i++)
            //{
            //    builderSmall.Append(stringShort);
            //}
            //sw.Stop();
            //long timeBuilderCollection = sw.ElapsedMilliseconds;

            //// test concatenations of structures
            //string testString = "";
            //sw.Start();
            //for (int i = 0; i < operationIts; i++)
            //{
            //    // test of simple string concatenation
            //    // testString = string.Concat(testString, stringShort);
            //    testString = string.Concat(testString, builderSmall[i]); // this returns i chars
            //}
            //sw.Stop();
            //long timeStringConcat = sw.ElapsedMilliseconds;
            //// View contents of structures
            //Console.WriteLine("String concatenation - " + operationIts + " iterations: " + timeStringConcat + " ms");
            ////Console.WriteLine("Stringbuilder contents: " + builderSmall.ToString());
            //Console.WriteLine("String contents: " + testString.ToString());
            //Console.WriteLine("Collection building - " + collectionIts + " iterations: " + timeBuilderCollection + " ms");
            //Console.WriteLine("Stringbuilder length: " + builderSmall.Length);
            //Console.WriteLine("Small string length: " + stringShort.Length + " times stringbuilder: " + (stringShort.Length * collectionIts));
            //Console.ReadLine();
        }

        public void testStructures()
        {

        }
    }
}
