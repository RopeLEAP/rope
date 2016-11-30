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
            char[] newArray = stringLong.ToCharArray();
            List<string> lines = new List<string>();

            // time filling of data structures with initial instance of string
            // ---------------------------------------------------------------
            // fill stringbuilder
            for (int i = 0; i < repetitions; i++)
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
                lines.Add($"Stringbuilder fill: {builderFill} ms");
                lines.Add($"Stringbuilder elapsed memory: {builderMem}");
            }


            // fill biglist
            for (int i = 0; i < repetitions; i++)
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
                lines.Add($"BigList fill: {biglistFill} ms");
                lines.Add($"BigList elapsed memory: {biglistMem}");
            }

            // fill rope
            for (int i = 0; i < repetitions; i++)
            {
                memStart = GC.GetTotalMemory(false);
                sw.Start();
                Rope.Rope<char> ropeLarge = new Rope.Rope<char>(newArray, 0, newArray.Length);
                sw.Stop();
                memEnd = GC.GetTotalMemory(false);
                ropeMem = memEnd - memStart;
                ropeFill = sw.ElapsedMilliseconds;
                //GC.Collect();
                lines.Add($"Rope fill: {ropeFill} ms");
                lines.Add($"Rope elapsed memory: {ropeMem}");
            }
            // write results
            using (StreamWriter writeResults = new StreamWriter(@"c:\repos\Rope\FillResults.txt"))
            {
                foreach (string line in lines)
                {
                    writeResults.WriteLine(line);
                }
            }

            // fill  with small string
            // Stringbuilder only has append, insert, remove and replace
            StringBuilder builderSmall = new StringBuilder();
            // BigList doesn't have a concat either
            BigList<string> biglistSmall = new BigList<string>();
            // Local rope structure
            Rope.Rope<string> ropeSmall = new Rope.Rope<string>();
            // fill strings with initial instance of short string
            builderSmall.Append(stringShort);
            biglistSmall.Add(stringShort);
            ropeSmall.Add(stringShort);
        }
    }
}
