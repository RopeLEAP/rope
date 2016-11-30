using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeTest
{
    class ConcatTest
    {
        // variables to set iterations and track times
        int operationIts = 1000;
        int collectionIts = 100000;

        //Create stopwatch. 
        Stopwatch sw = new Stopwatch();

        //Read in Strings.
        //long
        string warPeace = File.ReadAllText(@"C:\Users\v-elmacc\Documents\RopeProject\warandpeace.txt");
        //short
        string foxSentence = "The quick brown fox jumps over the lazy dog.";



        //Concat Rope.
        public void RopeConcatTestCreateRopes()
        {
            //Set Stopwatch.
            sw.Start();

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
            Console.WriteLine("Length of New Rope: " + ropeConcat.Length + "characters" + ", " + "Runtime: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }

        //Standard String Concat



        //Concat with StringBuilder.



        //Concat with Biglist
    }
}
