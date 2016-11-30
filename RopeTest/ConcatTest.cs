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
        string sentence = "The quick brown fox jumps over the lazy dog.";

        //Concatenate with various datatypes and time.

        //Concat Rope.


        //Standard String Concat



        //Concat with StringBuilder.



        //Concat with Biglist
    }
}
