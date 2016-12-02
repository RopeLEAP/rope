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
        int operationIts = 1000;
        int collectionIts = 100000;

        //Create stopwatch. 
        Stopwatch sw = new Stopwatch();

        //Concat Rope.
        public void RopeConcatTestCreateRopes()
        {
            //Set Stopwatch.
            sw.Start();

            //Read in Strings.
            //long
            string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");//Close file or methods after this won't run!
            //short
            string foxSentence = "The quick brown fox jumps over the lazy dog.";


            //Create new char arrays to populate ropes.
            char[] warPeaceArray = warPeace.ToCharArray();
            char[] foxSentenceArray = foxSentence.ToCharArray();

            //Fill Ropes.
            Rope.Rope<char> ropeWarPeace = new Rope.Rope<char>(warPeaceArray, 0, warPeaceArray.Length);
            Rope.Rope<char> ropeFoxSentence = new Rope.Rope<char>(foxSentenceArray, 0, foxSentenceArray.Length);

            //Concatenate Ropes.
            Rope.Rope<char> ropeConcat = Rope.Rope<char>.Concat(ropeWarPeace, ropeFoxSentence);

            //Time Stop
            sw.Stop();
            //Print time
            Console.WriteLine("Length of new rope: " + ropeConcat.Length + "characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }

        //Standard String Concat
        public void StringConcatReadStrings()
        {
            //Set Stopwatch.
            sw.Start();

            //Read in Strings.
            //long
            string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt"); //Close file or methods after this won't run, I think?
            //short
            string foxSentence = "The quick brown fox jumps over the lazy dog.";

            //Concatenate strings

           string stringConcat = warPeace + foxSentence; 

            //Time Stop
            sw.Stop();
            //Print time
            Console.WriteLine("Length of new string: " + stringConcat.Length + "characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();

        }


        //Concat with StringBuilder.
        public void StringBuilderConcatReadstrings()
        {
            //Set Stopwatch.
            sw.Start();

           //Read in Strings.
           //long
           string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");//Close file or methods after this won't run!
           //short
           string foxSentence = "The quick brown fox jumps over the lazy dog.";

           // Create new stringbuilder.
           StringBuilder combinedSB = new StringBuilder(warPeace);
            Console.WriteLine("First length: " + combinedSB.Length);
            //uses .Append to concat//
            combinedSB.Append(foxSentence);

            //Time Stop
            sw.Stop();

            //Print time
            Console.WriteLine("Length of new stringbuilder: " + combinedSB.Length + " characters" + "\n" + "Runtime: " + sw.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }



        //Concat with Biglist
        public void biglistConcatReadstrings()
        {
            BigList<char> combinedBL = new BigList<char>()
        }
        
    }
}
