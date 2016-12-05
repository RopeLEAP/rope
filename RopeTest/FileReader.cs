using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopeTest
{
    public class FileReader
    {
        // This class reads files in from the local disk
        // variables to hold file contents
        public string stringReadLong;
        // path and reader for file I/O
        public string longFilePath = @"c:\repos\files\warandpeace.txt";

        public string ReadTestFile()
        {
            using (StreamReader readLongFile = new StreamReader(longFilePath))
            {
                // read in long string file; create data structures to be tested
                stringReadLong = File.ReadAllText(longFilePath);
            }
            return stringReadLong;
        }
    }
}
