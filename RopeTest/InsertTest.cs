using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    class InsertTest
    {
        // variables to set iterations and track times
        int repetitions = 10;
        int iterations = 10;
        Stopwatch sw = new Stopwatch();
        // variables to hold file contetns
        string stringShort;
        string stringLong;
        // path and reader for file I/O
        string shortFilePath = @"c:\repos\Rope\foxText.txt";
        string longFilePath = @"c:\repos\Rope\warandpeace.txt";

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

        public void PrependToLargeStructures()
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
            char[] newArray = stringLong.ToCharArray();
            List<string> lines = new List<string>();

            // create datastructures with initial long string
            StringBuilder builderLarge = new StringBuilder(stringLong);
            BigList<char> biglistLarge = new BigList<char>(newArray);
            Rope.Rope<char> ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);

            // time filling of data structures with initial instance of string
            // ---------------------------------------------------------------
            // fill stringbuilder
            for (int i = 0; i < repetitions; i++)
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
                builderLarge.Clear();
                //GC.Collect();
                lines.Add($"Stringbuilder prepend: {builderFill} ms");
                lines.Add($"Stringbuilder elapsed memory: {builderMem}");
            }


            // fill biglist
            for (int i = 0; i < repetitions; i++)
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
                lines.Add($"BigList prepend: {biglistFill} ms");
                lines.Add($"BigList elapsed memory: {biglistMem}");
            }

            // insert into rope
            for (int i = 0; i < repetitions; i++)
            {
                memStart = GC.GetTotalMemory(false);
                sw.Start();
                ropeLarge.AddRange(newArray, 0, newArray.Length);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                ropeMem = memEnd - memStart;
                ropeFill = sw.ElapsedMilliseconds;
                //GC.Collect();
                lines.Add($"Rope prepend: {ropeFill} ms");
                lines.Add($"Rope elapsed memory: {ropeMem}");
            }
            // write results
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\Rope\InsertResults.txt"))
            {
                foreach (string line in lines)
                {
                    writeResults.WriteLine(line);
                }
            }
        }
    }
}
