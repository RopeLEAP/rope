using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rope
{
    /*
     * Operation                    |      Rope     |      String       |       StringBuilder       |    Database           |
     * ---------------------------------------------------------------------------------------------
     * Index                        |  O(log n)     |       O(1)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Split                        |  O(log n)     |       O(1)        |                          | 
     * ---------------------------------------------------------------------------------------------                         
     * Concatanate(destructive)     |  O(log n)     |       O(n)        |                          |
     * ---------------------------------------------------------------------------------------------                          
     * Concatanate(non-destructive) |  O(log n)     |       O(n)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Iterating                    |  O(n)         |       O(n)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Insert                       |  O(n)         |       O(n)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Append                       |  O(log n)     |   O(1) amortized  |                          |
     *                                                  O(n) worst case
     * ---------------------------------------------------------------------------------------------
     * Delete                       |  O(log n)     |       O(n)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Report                       |  O(j + log n) |       O(j)        |                          |
     * ---------------------------------------------------------------------------------------------
     * Build                        |  O(n)         |       O(n)        |                          |
     * ----------------------------------------------------------------------------------------------
     */

    class Program
    {
        static void Main(string[] args)
        {
            string testString = "The quick brown fox jumped over the lazy dog";
            string[] array = testString.Split();
            //start
            Rope<string> rope = new Rope<string>(array, 0, array.Length);

          //  Display(rope);
            //foreach (var r in rope)
            //{

            //}
            //stop
            Console.ReadLine();
        }

        static void Display(IEnumerable<string> rope)
        {
            foreach(string nde in rope)
            {
                Console.WriteLine(nde);
            }
        }
    }
}
