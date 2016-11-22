using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "The quick brown fox jumped over the lazy dog";
            string[] array = testString.Split();
            Rope<string> rope = new Rope<string>(array, 0, array.Length);

            Console.ReadLine();
        }
    }
}
