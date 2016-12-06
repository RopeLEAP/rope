using System;
using System.IO;

namespace RopeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----------------------------- this section contains function calls to the fill and insert service classes (sid) ----------------------- //

            /*
            //strings to hold json results
            string resultStringBuilder;
            string resultBigList;
            string resultRope;


            // FillService fills the data structures with the given number of strings of war and peace - this can run standalone and return resulting filled structures -InsertService will also run these
            //FillService fillService = new FillService();
            //fillService.ReadFiles();
            //fillService.FillLargeStructures();
            //resultStringBuilder = fillService.GetJsonSB();
            //resultBigList = fillService.GetJsonBL();
            //resultRope = fillService.GetJsonR();

            // InsertService calls FillService to fill the data structures with the given number of strings of war and peace, and then inserts another given number of strings to the beginning of the data structures
            InsertService insertService = new InsertService();
            insertService.ReadFiles();
            JsonService jsonService = new JsonService();

            // The first parameter defines how many times the insertion will occur; the second parameter defines how many times the initial fill will occur
            insertService.PrependToLargeStructures(50, 1);
            resultStringBuilder = jsonService.GetJsonSB();
            resultBigList = jsonService.GetJsonBL();
            resultRope = jsonService.GetJsonR();

            Console.WriteLine("Done!");
            Console.ReadLine();
            */

            // ----------------------------- this section contains function calls to the concat test class (liz) ---------------------- //

            // Create new Concatenate Test object.
            ConcatTest firstConcatTest = new ConcatTest(5,2);

            // Concatenate ropes and collect garbage to clear memory.
            //Possibly need to change split on this in the class, since it's now not the same len as the others.
            firstConcatTest.RopeConcatTestCreateRopes(); 
            GC.Collect();
            
            // Concatenate strings and collect garbage to clear memory.
            firstConcatTest.StringConcatReadStrings();
            GC.Collect();

            // Concatenate/Append StringBuilder and collect garbage to clear memory.
            firstConcatTest.StringBuilderConcatReadstrings();
            GC.Collect();

            // Concatenate/Append BigList and collect garbage to clear memory.
            firstConcatTest.BigListConcatReadStrings();
            //GC.Collect();
            
            // ----------------------------- this section contains function calls to the append test class (kwame) -------------------- //

        }
    }
}
