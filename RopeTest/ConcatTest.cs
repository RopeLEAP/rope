using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace RopeTest
{
    class ConcatTest
    {
        // Fields to set number of iterations in each test and how many replications. 
        int fNumIterations;
        int fNumReplications;

        public ConcatTest(int numIterations, int numreplications)
        {
            fNumReplications = numreplications;
            fNumIterations = numIterations;
        }

        // Filepaths
        //string warPeacePath = @"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt";
        StreamReader readFile = new StreamReader(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");
        string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");

        string foxSentence = "The quick brown fox jumps over the lazy dog.";
        
        // Create stopwatch. 
        Stopwatch sw = new Stopwatch();

        // memory variables
        long memStart = 0;
        long memEnd = 0;
        long memUsed = 0;

        // Method to Concatenate Ropes.
        public void RopeConcatTestCreateRopes()
        {
            //Lists to calculate averages.
            List<int> lengths = new List<int>();
            List<double> memallocs = new List<double>();
            List<double> runtimes = new List<double>();

            for (int i = 0; i < fNumReplications; i++) 
            {
                for( i = 0; i < fNumIterations; i++)
                {
                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(true);

                    // Short
                    //string foxSentence = "The quick brown fox jumps over the lazy dog.";
                    //char[] foxSentenceArray = foxSentence.ToCharArray();

                    // Set Stopwatch.
                    sw.Start();

                    // Read in Strings.

                    // Long
                    /*
                    StreamReader readFile = new StreamReader(warPeacePath);
                    string warPeace = File.ReadAllText(warPeacePath);
                    */


                    // Create new char arrays to populate ropes.
                    //char[] warPeaceArray = warPeace.ToCharArray();

                    // Fill Ropes.

                    /*
                    Rope.Rope<char> ropeWarPeace = new Rope.Rope<char>(warPeaceArray, 0, warPeaceArray.Length);
                    Rope.Rope<char> ropeFoxSentence = new Rope.Rope<char>(foxSentenceArray, 0, foxSentenceArray.Length);
                    */

                    //these should be faster than converting to charArray, and then you can just read the file in the very beginning and not count that in the time & memory!
                    Rope.Rope<string> ropeWarPeace = new Rope.Rope<string>(warPeace.Split(" ".ToCharArray()), 0 , warPeace.Length); //splits on word, can split on sentence too.
                    Rope.Rope<string> ropeFoxSentence = new Rope.Rope<string>(foxSentence.Split(" ".ToCharArray()), 0, foxSentence.Length);

                    // Concatenate Ropes.
                    //Rope.Rope<char> ropeConcat = Rope.Rope<char>.Concat(ropeWarPeace, ropeFoxSentence);
                    Rope.Rope<string> ropeConcat = Rope.Rope<string>.Concat(ropeWarPeace, ropeFoxSentence);

                    // Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    Console.WriteLine("Start {0} \nEnd {1}", memStart , memEnd);
                    //Calculate total memory.
                    memUsed = memEnd - memStart;

                    // Append values to each list.
                    lengths.Add(ropeConcat.Length);
                    memallocs.Add(memUsed); 
                    runtimes.Add(sw.ElapsedMilliseconds);

                    /*/////////////////////////////Test loops!!! /////////////////////////////*/

                    foreach (int element in lengths)
                    {
                        Console.WriteLine("Length: " + element);
                    }
                    foreach (double element in runtimes)
                    {
                        Console.WriteLine("Runtime: " + element);
                    }

                    foreach(double element in memallocs)
                    {
                        Console.WriteLine("Memory: " + element);
                    }
                    
                }

                // Print averages of ropeConcat.Length, Runtime, for each rep and export to JSON
                //Print time Will need to be JSON EXPORT!
                Console.WriteLine("Length of new rope: " + lengths.Sum() / lengths.Count() + " characters" +
                    "\nRuntime: " + runtimes.Sum()/lengths.Count() + " ms" +
                    "\nMemory used: " + memallocs.Sum()/memallocs.Count() + " bytes");
            }   
        }

        //Standard String Concat
        public void StringConcatReadStrings()
        {
            //Lists to calculate averages.
            List<int> lengths = new List<int>();
            List<double> memallocs = new List<double>();
            List<double> runtimes = new List<double>();

            for (int i = 0; i < fNumReplications; i++)
            {
                for (i = 0; i < fNumIterations; i++)
                {

                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(false);

                    // Set Stopwatch.
                    sw.Start();

                    // Read in Strings.

                    // Long
                    string warPeace = File.ReadAllText(warPeacePath);

                    // Short
                    string foxSentence = "The quick brown fox jumps over the lazy dog.";

                    // Concatenate strings
                    string stringConcat = warPeace + foxSentence;

                    // Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;

                    // Append values to each list.
                    lengths.Add(stringConcat.Length);
                    memallocs.Add(memUsed); 
                    runtimes.Add(sw.ElapsedMilliseconds);

                    /*/////////////////////////////Test loops!!! /////////////////////////////*/
                    foreach (int element in lengths)
                    {
                        Console.WriteLine("Length " + element);
                    }
                    foreach (double element in runtimes)
                    {
                        Console.WriteLine( "Runtime: " + element);
                    }

                    foreach (double element in memallocs)
                    {
                        Console.WriteLine( "Memory: " + element);
                    }
                }

                // Print time
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

            for (int i = 0; i < fNumReplications; i++)
            {
                for (i = 0; i < fNumIterations; i++)
                {

                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(false);

                    //Set Stopwatch.
                    sw.Start();

                    //Read in Strings.

                    // Long
                    string warPeace = File.ReadAllText(warPeacePath);

                    // Short
                    string foxSentence = "The quick brown fox jumps over the lazy dog.";

                    // Create new stringbuilder.
                    StringBuilder combinedSB = new StringBuilder(warPeace);

                    // "concatenate" strings using .Append method.
                    combinedSB.Append(foxSentence);

                    //Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;

                    // Append values to each list.
                    lengths.Add(combinedSB.Length);
                    memallocs.Add(memUsed); 
                    runtimes.Add(sw.ElapsedMilliseconds);

                    /*/////////////////////////////Test loops!!! /////////////////////////////*/
                    foreach (int element in lengths)
                    {
                        Console.WriteLine("Length " + element);
                    }
                    foreach (double element in runtimes)
                    {
                        Console.WriteLine("Runtime: " + element);
                    }

                    foreach (double element in memallocs)
                    {
                        Console.WriteLine("Memory: " + element);
                    }
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

            for (int i = 0; i < fNumReplications; i++)
            {
                for (i = 0; i < fNumIterations; i++)
                {
                    //Get memory pre-operation.
                    memStart = GC.GetTotalMemory(false);

                    // Start stopwatch.
                    sw.Start();

                    // Read in strings.

                    // Long
                    string warPeace = File.ReadAllText(warPeacePath);

                    // Short
                    string foxSentence = "The quick brown fox jumps over the lazy dog.";

                    // Create new BigList
                    BigList<char> combinedBL = new BigList<char>(warPeace);

                    //Convert foxSentence to charArray and .Add foxlist to BigList for concat.
                    combinedBL.AddRange(foxSentence);

                    //Time Stop
                    sw.Stop();

                    // Get Memory after operation.
                    memEnd = GC.GetTotalMemory(false);

                    //Calculate total memory.
                    memUsed = memEnd - memStart;

                    // Append values to each list.
                    lengths.Add(combinedBL.Count);
                    memallocs.Add(memUsed);
                    runtimes.Add(sw.ElapsedMilliseconds);

                    /*/////////////////////////////Test loops!!! /////////////////////////////*/
                    foreach (int element in lengths)
                    {
                        Console.WriteLine("Length " + element);
                    }
                    foreach (double element in runtimes)
                    {
                        Console.WriteLine("Runtime: " + element);
                    }

                    foreach (double element in memallocs)
                    {
                        Console.WriteLine("Memory: " + element);
                    }
                }
                // Print results
                Console.WriteLine("Length of new stringBuilder: " + lengths.Sum() / lengths.Count() + " characters" +
                        "\nRuntime: " + runtimes.Sum() / lengths.Count() + " ms" +
                        "\nMemory used: " + memallocs.Sum() / memallocs.Count() + " bytes");

            }

            // Read Results.
            Console.ReadLine();
        }
       
    }
}
