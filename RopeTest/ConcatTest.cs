using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace RopeTest
{
    class ConcatTest
    {
        // variables to set iterations and track times
        int operationIts = 1000;//Replecations
        int collectionIts = 100000; //itirations

        // Filepaths
        string warPeacePath = @"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt";

        // Create stopwatch. 
        Stopwatch sw = new Stopwatch();

        // Method to Concatenate Ropes.
        public void RopeConcatTestCreateRopes()
        {
            // Set Stopwatch.
            sw.Start();

            // Read in Strings.
            
            // Long
            StreamReader readFile = new StreamReader(warPeacePath);
            string warPeace = File.ReadAllText(warPeacePath);
      
            // Short
            string foxSentence = "The quick brown fox jumps over the lazy dog.";


            // Create new char arrays to populate ropes.
            char[] warPeaceArray = warPeace.ToCharArray();
            char[] foxSentenceArray = foxSentence.ToCharArray();

            // Fill Ropes.
            Rope.Rope<char> ropeWarPeace = new Rope.Rope<char>(warPeaceArray, 0, warPeaceArray.Length);
            Rope.Rope<char> ropeFoxSentence = new Rope.Rope<char>(foxSentenceArray, 0, foxSentenceArray.Length);

            // Concatenate Ropes.
            Rope.Rope<char> ropeConcat = Rope.Rope<char>.Concat(ropeWarPeace, ropeFoxSentence);

            //Time Stop
            sw.Stop();
           
            //Print time
            Console.WriteLine("Length of new rope: " + ropeConcat.Length + " characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + " ms");
          }

        //Standard String Concat
        public void StringConcatReadStrings()
        {
            // Set Stopwatch.
            sw.Start();

            // Read in Strings.

            // Long
            using (StreamReader readFile = new StreamReader(warPeacePath))
            {
                string warPeace = File.ReadAllText(warPeacePath); // Need to access outside the brackets or there is scope issue.
        
            // Short
            string foxSentence = "The quick brown fox jumps over the lazy dog.";

            // Concatenate strings
            string stringConcat = warPeace + foxSentence; 

            // Time Stop
            sw.Stop();

            // Print time
            Console.WriteLine("Length of new string: " + stringConcat.Length + " characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + " ms");
            }
        }

        //Concat with StringBuilder.
        public void StringBuilderConcatReadstrings()
        {
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

                //Print time
                Console.WriteLine("Length of new stringbuilder: " + combinedSB.Length + " characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + " ms");
      
        }

        //Concat with Biglist
        public void BigListConcatReadStrings()
        {
            // Start stopwatch.
            sw.Start();
            using (StreamReader readShortFile = new StreamReader(warPeacePath))
            {
                // Read in strings.
                
                // Long
                string warPeace = File.ReadAllText(warPeacePath);
                
                // Short
                string foxSentence = "The quick brown fox jumps over the lazy dog.";

                // Create new BigList
                BigList<char> combinedBL = new BigList<char>(warPeace);

                //Convert foxSentence to charArran and .Add foxlist to BigList for concat.
                combinedBL.AddRange(foxSentence);

                //Time Stop
                sw.Stop();

                Console.WriteLine("Length of new BigList: " + combinedBL.Count + " characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + " ms");
            }
            // Read Results.
            Console.ReadLine();
        }
          
    }
}
